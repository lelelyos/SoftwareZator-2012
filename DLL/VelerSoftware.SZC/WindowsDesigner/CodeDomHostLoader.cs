// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using System.CodeDom.Compiler;
using System.CodeDom;
using System.Drawing;
using Microsoft.CSharp;
using Microsoft.VisualBasic;

namespace VelerSoftware.SZC.WindowsDesigner
{
    /// <summary>
    /// Inherits from CodeDomDesignerLoader. It can generate C# or VB code
    /// for a HostSurface. This loader does not support parsing a 
    /// C# or VB file.
    /// </summary>
    public class CodeDomHostLoader : System.ComponentModel.Design.Serialization.CodeDomDesignerLoader
	{
        VBCodeProvider _csCodeProvider = new VBCodeProvider();
	    public CodeCompileUnit codeCompileUnit = null;
		TypeResolutionService _trs = null;
        public string NomProjet = null;
        public VelerSoftware.SZVB.Projet.SZW_File Fichier = null;
        public System.Collections.Generic.List<VelerSoftware.SZVB.Projet.Reference> Ass;

		
		public CodeDomHostLoader()
		{
            this.EnableComponentNotification(true);
			_trs = new TypeResolutionService();
			AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(LoadFromSameFolderResolveEventHandler);
		}

        protected override ITypeResolutionService TypeResolutionService
		{
			get
			{
				return _trs;
			}
		}

		protected override CodeDomProvider CodeDomProvider
		{
			get
			{
				return _csCodeProvider;
			}
		}

        /// <summary>
        /// Bootstrap method - loads a blank Form
        /// </summary>
        /// <returns></returns>
        protected override CodeCompileUnit Parse()
        {
            CodeCompileUnit ccu = new System.CodeDom.CodeCompileUnit();

			ReloadAssemblys(ccu);

            ccu = Fichier.WINDOWS;

            codeCompileUnit = ccu;
            return ccu;
        }

		static Assembly LoadFromSameFolderResolveEventHandler(object sender, ResolveEventArgs args)
		{
			string folderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			string assemblyPath = Path.Combine(folderPath, args.Name);
            try
            {
                Assembly assembly = Assembly.LoadFile(assemblyPath);
                return assembly;
            }
            catch
            {
                return null;
            }
		}

        /// <summary>
        /// When the Loader is Flushed this method is called. The base class
        /// (CodeDomDesignerLoader) creates the CodeCompileUnit. We
        /// simply cache it and use this when we need to generate code from it.
        /// To generate the code we use CodeProvider.
        /// </summary>
		protected override void Write(CodeCompileUnit unit)
		{
			codeCompileUnit = unit;
		}

        /// <summary>
        /// When the Loader is Flushed this method is called. The base class
        /// (CodeDomDesignerLoader) creates the CodeCompileUnit. We
        /// simply cache it and use this when we need to generate code from it.
        /// To generate the code we use CodeProvider.
        /// </summary>
        public void Writes(CodeCompileUnit unit)
        {
            codeCompileUnit = unit;
        }

		protected override void OnEndLoad(bool successful, ICollection errors)
		{
			base.OnEndLoad(successful, errors);
			if (this.OnEndLoaded != null)
			{
				this.OnEndLoaded(successful, errors);
			}
		}

		/// <summary>
		/// Declare un delegate
		/// </summary>
		public delegate void OnEndLoadedEventHandler(bool successful, ICollection errors);
		/// <summary>
		/// Declare un evenement qui va contenir les informations que nous souhaitons envoyer
		/// </summary>
		public event OnEndLoadedEventHandler OnEndLoaded;



        #region Public methods

        /// <summary>
        /// Flushes the host and returns the updated CodeCompileUnit
        /// </summary>
        /// <returns></returns>
        public CodeCompileUnit GetCodeCompileUnit()
        {
            Flush();

            foreach (System.CodeDom.CodeTypeMember metho in codeCompileUnit.Namespaces[0].Types[0].Members)
            {
                if (metho.Name == "InitializeComponent")
                {
                    System.Collections.Generic.List<System.CodeDom.CodeStatement> stats = new System.Collections.Generic.List<System.CodeDom.CodeStatement>();
                    foreach (System.CodeDom.CodeStatement stat in ((System.CodeDom.CodeMemberMethod)metho).Statements)
                    {
                        if ((stat is System.CodeDom.CodeAssignStatement) && (((System.CodeDom.CodeAssignStatement)stat).Right is System.CodeDom.CodeFieldReferenceExpression) && (((System.CodeDom.CodeFieldReferenceExpression)((System.CodeDom.CodeAssignStatement)stat).Right).TargetObject is System.CodeDom.CodeTypeReferenceExpression))
                        {
                            if (((System.CodeDom.CodeTypeReferenceExpression)((System.CodeDom.CodeFieldReferenceExpression)((System.CodeDom.CodeAssignStatement)stat).Right).TargetObject).Type.BaseType + "." + ((System.CodeDom.CodeFieldReferenceExpression)((System.CodeDom.CodeAssignStatement)stat).Right).FieldName == "System.Windows.Forms.RightToLeft.No")
                            {
                                stats.Add(stat);
                            }
                        }
                    }
                    foreach (System.CodeDom.CodeStatement stat in stats)
                    {
                        ((System.CodeDom.CodeMemberMethod)metho).Statements.Remove(stat);
                    }
                }
            }


            return codeCompileUnit;
        }

        /// <summary>
        /// This method writes out the contents of our designer in C# and VB.
        /// It generates code from our codeCompileUnit using CodeRpovider
        /// </summary>
        public string GetCode()
        {
            Flush();

            CodeGeneratorOptions o = new CodeGeneratorOptions();

            o.BlankLinesBetweenMembers = true;
            o.BracingStyle = "VB";
            o.ElseOnClosing = true;
            o.VerbatimOrder = true;
            o.IndentString = "    ";

            StringWriter swVB = new StringWriter();
            VBCodeProvider vb = new VBCodeProvider();

            vb.GenerateCodeFromCompileUnit(codeCompileUnit, swVB, o);
            string code = swVB.ToString();
            swVB.Close();
            return code;
        }

        /// <summary>
        /// Chargement des assemblys
        /// </summary>
        public void LoadAssembly()
        {
            for (int i = 0; i < this.Ass.Count; i++)
            {
                if ((this.Ass[i] != null) && (this.Ass[i].Assembly != null))
                    {
                           System.Reflection.Assembly.LoadFile(this.Ass[i].Location);
                           AppDomain.CurrentDomain.Load(this.Ass[i].Location);
                        
                    }
            }
        }

        public CodeCompileUnit ReloadAssemblys(CodeCompileUnit ccu)
        {
            ccu.ReferencedAssemblies.Clear();

            for (int i = 0; i < this.Ass.Count; i++)
            {
                if ((this.Ass[i] != null) && (this.Ass[i].Assembly != null))
                    {
                        Assembly assembly = this.Ass[i].Assembly;
                        if (System.IO.File.Exists(assembly.Location))
                        {
                            System.Reflection.Assembly.LoadFile(assembly.Location); 
                            AppDomain.CurrentDomain.Load(assembly.Location);
                            ccu.ReferencedAssemblies.Add(assembly.Location);
                        }
                    }
            }

            AssemblyName[] names = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
            for (int i = 0; i < names.Length; i++)
            {
                Assembly assembly = Assembly.Load(names[i]);
                ccu.ReferencedAssemblies.Add(assembly.Location);
            }

            return ccu;
        }

        #endregion


	}// class
}// namespace
