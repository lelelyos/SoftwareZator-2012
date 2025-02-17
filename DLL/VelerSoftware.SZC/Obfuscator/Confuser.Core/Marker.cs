﻿// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Mono.Cecil;
using Mono.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Xml;

namespace VelerSoftware.SZC.Obfuscator.Confuser.Core
{
    public class Marker
    {
        public static readonly List<string> FrameworkAssemblies;
        static Marker()
        {
            FrameworkAssemblies = new List<string>();
            foreach (FileInfo file in Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.System)).GetDirectories("Microsoft.NET")[0].GetFiles("FrameworkList.xml", SearchOption.AllDirectories))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(file.FullName);
                foreach (XmlNode xn in doc.SelectNodes("/FileList/File"))
                {
                    byte[] tkn = new byte[8];
                    string tknStr = xn.Attributes["PublicKeyToken"].Value;
                    for (int i = 0; i < 8; i++)
                        tkn[i] = Convert.ToByte(tknStr.Substring(i * 2, 2), 16);
                    FrameworkAssemblies.Add(string.Format("{0}/{1}", xn.Attributes["AssemblyName"].Value, BitConverter.ToString(tkn ?? new byte[0])));
                }
            }
            foreach (string file in Directory.GetFiles(Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Reference Assemblies")[0], "FrameworkList.xml", SearchOption.AllDirectories))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(file);
                foreach (XmlNode xn in doc.SelectNodes("/FileList/File"))
                {
                    byte[] tkn = new byte[8];
                    string tknStr = xn.Attributes["PublicKeyToken"].Value;
                    for (int i = 0; i < 8; i++)
                        tkn[i] = Convert.ToByte(tknStr.Substring(i * 2, 2), 16);
                    FrameworkAssemblies.Add(string.Format("{0}/{1}", xn.Attributes["AssemblyName"].Value, BitConverter.ToString(tkn ?? new byte[0])));
                }
            }
        }

        class Settings
        {
            public Settings()
            {
                inheritStack = new Stack<Dictionary<IConfusion, NameValueCollection>>();
                StartLevel();
            }

            Stack<Dictionary<IConfusion, NameValueCollection>> inheritStack;
            public Dictionary<IConfusion, NameValueCollection> CurrentConfusions;

            public void StartLevel()
            {
                if (inheritStack.Count > 0)
                    CurrentConfusions = new Dictionary<IConfusion, NameValueCollection>(inheritStack.Peek());
                else
                    CurrentConfusions = new Dictionary<IConfusion, NameValueCollection>();
                inheritStack.Push(CurrentConfusions);
            }
            public void LeaveLevel()
            {
                inheritStack.Pop();
                CurrentConfusions = inheritStack.Peek();
            }
            public void SkipLevel()
            {
                if (inheritStack.Count > 1)
                    CurrentConfusions = new Dictionary<IConfusion, NameValueCollection>(inheritStack.ToArray()[inheritStack.Count - 2]);
                else
                    CurrentConfusions = new Dictionary<IConfusion, NameValueCollection>();
                inheritStack.Push(CurrentConfusions);
            }
        }

        protected IDictionary<string, IConfusion> Confusions;
        protected IDictionary<string, Packer> Packers;
        public virtual void Initalize(IConfusion[] cions, Packer[] packs)
        {
            Confusions = new Dictionary<string, IConfusion>();
            foreach (IConfusion c in cions)
                Confusions.Add(c.ID, c);
            Packers = new Dictionary<string, Packer>();
            foreach (Packer pack in packs)
                Packers.Add(pack.ID, pack);
        }
        private void FillPreset(Preset preset, Dictionary<IConfusion, NameValueCollection> cs)
        {
            foreach (IConfusion i in Confusions.Values)
                if (i.Preset <= preset && !cs.ContainsKey(i))
                    cs.Add(i, new NameValueCollection());
        }

        Confuser cr;
        protected Confuser Confuser { get { return cr; } set { cr = value; } }
        private bool ProcessAttribute(ICustomAttributeProvider provider, Settings setting)
        {
            CustomAttribute att = GetAttribute(provider.CustomAttributes, "ConfusingAttribute");
            if (att == null)
            {
                setting.StartLevel();
                return false;
            }

            CustomAttributeNamedArgument stripArg = att.Properties.FirstOrDefault(arg => arg.Name == "StripAfterObfuscation");
            bool strip = true;
            if (!stripArg.Equals(default(CustomAttributeNamedArgument)))
                strip = (bool)stripArg.Argument.Value;

            if (strip)
                provider.CustomAttributes.Remove(att);

            CustomAttributeNamedArgument excludeArg = att.Properties.FirstOrDefault(arg => arg.Name == "Exclude");
            bool exclude = false;
            if (!excludeArg.Equals(default(CustomAttributeNamedArgument)))
                exclude = (bool)excludeArg.Argument.Value;

            if (exclude)
                setting.CurrentConfusions.Clear();

            CustomAttributeNamedArgument applyToMembersArg = att.Properties.FirstOrDefault(arg => arg.Name == "ApplyToMembers");
            bool applyToMembers = true;
            if (!applyToMembersArg.Equals(default(CustomAttributeNamedArgument)))
                applyToMembers = (bool)applyToMembersArg.Argument.Value;

            if (applyToMembers)
                setting.StartLevel();
            else
                setting.SkipLevel();
            try
            {
                if (!exclude)
                {
                    CustomAttributeNamedArgument featureArg = att.Properties.FirstOrDefault(arg => arg.Name == "Config");
                    string feature = "all";
                    if (!featureArg.Equals(default(CustomAttributeNamedArgument)))
                        feature = (string)featureArg.Argument.Value;

                    if (string.Equals(feature, "all", StringComparison.OrdinalIgnoreCase))
                        FillPreset(Preset.Maximum, setting.CurrentConfusions);
                    else if (string.Equals(feature, "default", StringComparison.OrdinalIgnoreCase))
                        FillPreset(Preset.Normal, setting.CurrentConfusions);
                    else
                        ProcessConfig(feature, setting.CurrentConfusions);
                }

                return exclude && applyToMembers;
            }
            catch
            {
                cr.Log("Warning: Cannot process ConfusingAttribute at '" + provider.ToString() + "'. ConfusingAttribute ignored.");
                return false;
            }
        }
        private CustomAttribute GetAttribute(Collection<CustomAttribute> attributes, string name)
        {
            return attributes.FirstOrDefault((att) => att.AttributeType.FullName == name);
        }
        private void ProcessConfig(string cfg, Dictionary<IConfusion, NameValueCollection> cs)
        {
            MatchCollection matches = Regex.Matches(cfg, @"(\+|\-|)\[([^,\]]*)(?:,([^\]]*))?\]");
            foreach (Match match in matches)
            {
                string id = match.Groups[2].Value.ToLower();
                switch (match.Groups[1].Value)
                {
                    case null:
                    case "":
                    case "+":
                        if (id == "preset")
                        {
                            FillPreset((Preset)Enum.Parse(typeof(Preset), match.Groups[3].Value, true), cs);
                        }
                        else if (id == "new")
                        {
                            cs.Clear();
                        }
                        else
                        {
                            if (!Confusions.ContainsKey(id))
                            {
                                cr.Log("Warning: Cannot find confusion id '" + id + "'.");
                                break;
                            }
                            IConfusion now = (from i in cs.Keys where i.ID == id select i).FirstOrDefault() ?? Confusions[id];
                            if (!cs.ContainsKey(now)) cs[now] = new NameValueCollection();
                            NameValueCollection nv = cs[now];
                            if (!string.IsNullOrEmpty(match.Groups[3].Value))
                            {
                                foreach (string param in match.Groups[3].Value.Split(','))
                                {
                                    string[] p = param.Split('=');
                                    if (p.Length == 1)
                                        nv[p[0].ToLower()] = "true";
                                    else
                                        nv[p[0].ToLower()] = p[1];
                                }
                            }
                        }
                        break;
                    case "-":
                        cs.Remove((from i in cs.Keys where i.ID == id select i).FirstOrDefault());
                        break;
                }
            }
        }
        private void ProcessPackers(ICustomAttributeProvider provider, out NameValueCollection param, out Packer packer)
        {
            CustomAttribute attr = GetAttribute(provider.CustomAttributes, "PackerAttribute");

            if (attr == null) { param = null; packer = null; return; }
            CustomAttributeNamedArgument stripArg = attr.Properties.FirstOrDefault(arg => arg.Name == "StripAfterObfuscation");
            bool strip = true;
            if (!stripArg.Equals(default(CustomAttributeNamedArgument)))
                strip = (bool)stripArg.Argument.Value;

            if (strip)
                provider.CustomAttributes.Remove(attr);

            CustomAttributeNamedArgument cfgArg = attr.Properties.FirstOrDefault(arg => arg.Name == "Config");
            string cfg = "";
            if (!cfgArg.Equals(default(CustomAttributeNamedArgument)))
                cfg = (string)cfgArg.Argument.Value;
            if (string.IsNullOrEmpty(cfg)) { param = null; packer = null; return; }

            param = new NameValueCollection();

            Match match = Regex.Match(cfg, @"([^:]*):?(?:([^=]*=[^,]*),?)*");
            packer = Packers[match.Groups[1].Value];
            foreach (Capture arg in match.Groups[2].Captures)
            {
                string[] args = arg.Value.Split('=');
                param.Add(args[0], args[1]);
            }
        }
        private bool IsExcludedDependency(ICustomAttributeProvider provider, AssemblyNameReference refer)
        {
            foreach (CustomAttribute attr in provider.CustomAttributes)
            {
                if (attr.AttributeType.FullName == "ExcludeDependencyAttribute" &&
                    attr.ConstructorArguments[0].Value.ToString() == refer.ToString())
                    return true;
            }
            return false;
        }

        public virtual AssemblyDefinition[] GetAssemblies(string src, Preset preset, Confuser cr, EventHandler<LogEventArgs> err)
        {
            this.cr = cr;
            Settings setting = new Settings();
            FillPreset(preset, setting.CurrentConfusions);
            Dictionary<string, AssemblyDefinition> ret = new Dictionary<string, AssemblyDefinition>();

            AssemblyDefinition main = AssemblyDefinition.ReadAssembly(src);
            MarkAssembly(main, setting);
            ret.Add(main.FullName, main);
            foreach (ModuleDefinition mod in main.Modules)
            {
                mod.FullLoad();
                foreach (AssemblyNameReference refer in mod.AssemblyReferences)
                {
                    if (!FrameworkAssemblies.Contains(string.Format("{0}/{1}", refer.Name, BitConverter.ToString(refer.PublicKeyToken ?? new byte[0]))) && !ret.ContainsKey(refer.FullName) && !IsExcludedDependency(main, refer))
                    {
                        AssemblyDefinition asm = GlobalAssemblyResolver.Instance.Resolve(refer);
                        if (asm == null)
                        {
                            err(this, new LogEventArgs(string.Format("WARNING : Cannot load dependency '" + refer.FullName + ".")));
                        }
                        else
                        {
                            MarkAssembly(asm, setting);
                            ret.Add(refer.FullName, asm);
                            GetAssemblies(asm, setting, ret, err);
                        }
                    }
                }
            }
            return ret.Values.ToArray();
        }
        void GetAssemblies(AssemblyDefinition asm, Settings setting, Dictionary<string, AssemblyDefinition> ret, EventHandler<LogEventArgs> err)
        {
            foreach (ModuleDefinition mod in asm.Modules)
            {
                mod.FullLoad();
                foreach (AssemblyNameReference refer in mod.AssemblyReferences)
                {
                    if (!FrameworkAssemblies.Contains(string.Format("{0}/{1}", refer.Name, BitConverter.ToString(refer.PublicKeyToken ?? new byte[0]))) && !ret.ContainsKey(refer.FullName) && !IsExcludedDependency(asm, refer))
                    {
                        AssemblyDefinition asmRef = GlobalAssemblyResolver.Instance.Resolve(refer);
                        if (asmRef == null)
                        {
                            err(this, new LogEventArgs(string.Format("WARNING : Cannot load dependency '" + refer.FullName + ".")));
                        }
                        else
                        {
                            MarkAssembly(asmRef, setting);
                            ret.Add(refer.FullName, asmRef);
                            GetAssemblies(asmRef, setting, ret, err);
                        }
                    }
                }
            }
        }
        protected void MarkAssemblies(AssemblyDefinition[] assemblies, Preset preset)
        {
            Settings setting = new Settings();
            FillPreset(preset, setting.CurrentConfusions);
            Dictionary<string, AssemblyDefinition> ret = new Dictionary<string, AssemblyDefinition>();

            foreach (AssemblyDefinition asm in assemblies)
            {
                MarkAssembly(asm, setting);
            }
        }

        internal void MarkHelperAssembly(AssemblyDefinition asm)
        {
            MarkAssembly(asm, new Settings());
        }
        private void MarkAssembly(AssemblyDefinition asm, Settings setting)
        {
            bool exclude = ProcessAttribute(asm, setting);
            MarkAssembly(asm, setting.CurrentConfusions, cr);

            (asm as IAnnotationProvider).Annotations["ConfusionSets"] = setting.CurrentConfusions;
            (asm as IAnnotationProvider).Annotations["GlobalParams"] = setting.CurrentConfusions;

            NameValueCollection param;
            Packer packer;
            ProcessPackers(asm, out param, out packer);
            (asm as IAnnotationProvider).Annotations["Packer"] = packer;
            (asm as IAnnotationProvider).Annotations["PackerParams"] = param;

            if (!exclude)
                foreach (ModuleDefinition mod in asm.Modules)
                    MarkModule(mod, setting);

            setting.LeaveLevel();
        }
        protected virtual void MarkAssembly(AssemblyDefinition asm, IDictionary<IConfusion, NameValueCollection> current, Confuser cr) { }

        private void MarkModule(ModuleDefinition mod, Settings setting)
        {
            bool exclude = ProcessAttribute(mod, setting);
            MarkModule(mod, setting.CurrentConfusions, cr);

            (mod as IAnnotationProvider).Annotations["ConfusionSets"] = setting.CurrentConfusions;

            if (!exclude)
                foreach (TypeDefinition type in mod.Types)
                {
                    setting.StartLevel();
                    MarkType(type, setting);
                    setting.LeaveLevel();
                }

            setting.LeaveLevel();
        }
        protected virtual void MarkModule(ModuleDefinition mod, IDictionary<IConfusion, NameValueCollection> current, Confuser cr) { }

        private void MarkType(TypeDefinition type, Settings setting)
        {
            bool exclude = ProcessAttribute(type, setting);
            MarkType(type, setting.CurrentConfusions, cr);

            (type as IAnnotationProvider).Annotations["ConfusionSets"] = setting.CurrentConfusions;


            if (!exclude)
            {
                foreach (TypeDefinition nType in type.NestedTypes)
                {
                    setting.StartLevel();
                    MarkType(nType, setting);
                    setting.LeaveLevel();
                }

                foreach (MethodDefinition mtd in type.Methods)
                {
                    setting.StartLevel();
                    MarkMember(mtd, setting, Target.Methods);
                    setting.LeaveLevel();
                }

                foreach (FieldDefinition fld in type.Fields)
                {
                    setting.StartLevel();
                    MarkMember(fld, setting, Target.Fields);
                    setting.LeaveLevel();
                }

                foreach (PropertyDefinition prop in type.Properties)
                {
                    setting.StartLevel();
                    MarkMember(prop, setting, Target.Properties);
                    setting.LeaveLevel();
                }

                foreach (EventDefinition evt in type.Events)
                {
                    setting.StartLevel();
                    MarkMember(evt, setting, Target.Events);
                    setting.LeaveLevel();
                }
            }

            setting.LeaveLevel();
        }
        protected virtual void MarkType(TypeDefinition type, IDictionary<IConfusion, NameValueCollection> current, Confuser cr) { }

        private void MarkMember(IMemberDefinition mem, Settings setting, Target target)
        {
            if (target == Target.Methods && (mem as MethodDefinition).SemanticsAttributes != MethodSemanticsAttributes.None)
            {
                return;
            }

            bool exclude = ProcessAttribute(mem, setting);
            MarkMember(mem, setting.CurrentConfusions, cr);

            (mem as IAnnotationProvider).Annotations["ConfusionSets"] = setting.CurrentConfusions;

            if (!exclude)
                if (target == Target.Properties)
                {
                    PropertyDefinition prop = mem as PropertyDefinition;
                    List<MethodDefinition> sems = new List<MethodDefinition>();
                    if (prop.GetMethod != null)
                        sems.Add(prop.GetMethod);
                    if (prop.SetMethod != null)
                        sems.Add(prop.SetMethod);
                    if (prop.HasOtherMethods)
                        sems.AddRange(prop.OtherMethods);
                    foreach (MethodDefinition mtd in sems)
                    {
                        setting.StartLevel();
                        ProcessAttribute(mtd, setting);
                        (mtd as IAnnotationProvider).Annotations["ConfusionSets"] = setting.CurrentConfusions;
                        setting.LeaveLevel();
                        setting.LeaveLevel();
                    }
                }
                else if (target == Target.Events)
                {
                    EventDefinition evt = mem as EventDefinition;
                    List<MethodDefinition> sems = new List<MethodDefinition>();
                    if (evt.AddMethod != null)
                        sems.Add(evt.AddMethod);
                    if (evt.RemoveMethod != null)
                        sems.Add(evt.RemoveMethod);
                    if (evt.InvokeMethod != null)
                        sems.Add(evt.InvokeMethod);
                    if (evt.HasOtherMethods)
                        sems.AddRange(evt.OtherMethods);
                    foreach (MethodDefinition mtd in sems)
                    {
                        setting.StartLevel();
                        ProcessAttribute(mtd, setting);
                        (mtd as IAnnotationProvider).Annotations["ConfusionSets"] = setting.CurrentConfusions;
                        setting.LeaveLevel();
                        setting.LeaveLevel();
                    }
                }

            setting.LeaveLevel();
        }
        protected virtual void MarkMember(IMemberDefinition mem, IDictionary<IConfusion, NameValueCollection> current, Confuser cr) { }

        public virtual string GetDestinationPath(ModuleDefinition mod, string dstPath)
        {
            string ret = mod.Name;
            if(string.IsNullOrEmpty(Path.GetExtension(ret)))
                switch (mod.Kind)
                {
                    case ModuleKind.Console:
                    case ModuleKind.Windows:
                        ret = Path.ChangeExtension(ret, "exe"); break;
                    case ModuleKind.Dll:
                        ret = Path.ChangeExtension(ret, "dll"); break;
                    case ModuleKind.NetModule:
                        ret = Path.ChangeExtension(ret, "netmodule"); break;
                }
            return Path.Combine(dstPath, ret);
        }
    }
    class CopyMarker : Marker
    {
        AssemblyDefinition origin;
        IConfusion exclude;
        public CopyMarker(AssemblyDefinition asm, IConfusion exclude) { origin = asm; this.exclude = exclude; }
        protected override void MarkAssembly(AssemblyDefinition asm, IDictionary<IConfusion, NameValueCollection> current, Confuser cr)
        {
            current.Clear();
            foreach (var i in (IDictionary<IConfusion, NameValueCollection>)((IAnnotationProvider)origin).Annotations["ConfusionSets"])
                if (i.Key != exclude)
                    current.Add(i);
        }
    }
}
