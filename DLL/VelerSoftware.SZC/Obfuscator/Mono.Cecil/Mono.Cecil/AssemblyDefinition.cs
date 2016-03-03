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
using System.IO;

using Mono.Collections.Generic;

namespace Mono.Cecil {

	public sealed class AssemblyDefinition : ICustomAttributeProvider, ISecurityDeclarationProvider, IAnnotationProvider {

		AssemblyNameDefinition name;

		internal ModuleDefinition main_module;
		Collection<ModuleDefinition> modules;
		Collection<CustomAttribute> custom_attributes;
		Collection<SecurityDeclaration> security_declarations;

		public AssemblyNameDefinition Name {
			get { return name; }
			set { name = value; }
		}

		public string FullName {
			get { return name != null ? name.FullName : string.Empty; }
		}

		public MetadataToken MetadataToken {
			get { return new MetadataToken (TokenType.Assembly, 1); }
			set { }
		}

		public Collection<ModuleDefinition> Modules {
			get {
				if (modules != null)
					return modules;

				if (main_module.HasImage)
					return modules = main_module.Read (this, (_, reader) => reader.ReadModules ());

				return modules = new Collection<ModuleDefinition> (1) { main_module };
			}
		}

		public ModuleDefinition MainModule {
			get { return main_module; }
		}

		public MethodDefinition EntryPoint {
			get { return main_module.EntryPoint; }
			set { main_module.EntryPoint = value; }
		}

		public bool HasCustomAttributes {
			get {
				if (custom_attributes != null)
					return custom_attributes.Count > 0;

				return this.GetHasCustomAttributes (main_module);
			}
		}

		public Collection<CustomAttribute> CustomAttributes {
			get { return custom_attributes ?? (custom_attributes = this.GetCustomAttributes (main_module)); }
		}

		public bool HasSecurityDeclarations {
			get {
				if (security_declarations != null)
					return security_declarations.Count > 0;

				return this.GetHasSecurityDeclarations (main_module);
			}
		}

		public Collection<SecurityDeclaration> SecurityDeclarations {
			get { return security_declarations ?? (security_declarations = this.GetSecurityDeclarations (main_module)); }
		}

		internal AssemblyDefinition ()
		{
		}

#if !READ_ONLY
		public static AssemblyDefinition CreateAssembly (AssemblyNameDefinition assemblyName, string moduleName, ModuleKind kind)
		{
			return CreateAssembly (assemblyName, moduleName, new ModuleParameters { Kind = kind });
		}

		public static AssemblyDefinition CreateAssembly (AssemblyNameDefinition assemblyName, string moduleName, ModuleParameters parameters)
		{
			if (assemblyName == null)
				throw new ArgumentNullException ("assemblyName");
			if (moduleName == null)
				throw new ArgumentNullException ("moduleName");
			Mixin.CheckParameters (parameters);
			if (parameters.Kind == ModuleKind.NetModule)
				throw new ArgumentException ("kind");

			var assembly = ModuleDefinition.CreateModule (moduleName, parameters).Assembly;
			assembly.Name = assemblyName;

			return assembly;
		}
#endif

		public static AssemblyDefinition ReadAssembly (string fileName)
		{
			return ReadAssembly (ModuleDefinition.ReadModule (fileName));
		}

		public static AssemblyDefinition ReadAssembly (string fileName, ReaderParameters parameters)
		{
			return ReadAssembly (ModuleDefinition.ReadModule (fileName, parameters));
		}

		public static AssemblyDefinition ReadAssembly (Stream stream)
		{
			return ReadAssembly (ModuleDefinition.ReadModule (stream));
		}

		public static AssemblyDefinition ReadAssembly (Stream stream, ReaderParameters parameters)
		{
			return ReadAssembly (ModuleDefinition.ReadModule (stream, parameters));
		}

		static AssemblyDefinition ReadAssembly (ModuleDefinition module)
		{
			var assembly = module.Assembly;
			if (assembly == null)
				throw new ArgumentException ();

			return assembly;
		}

#if !READ_ONLY
		public void Write (string fileName)
		{
			Write (fileName, new WriterParameters ());
		}

		public void Write (Stream stream)
		{
			Write (stream, new WriterParameters ());
		}

		public void Write (string fileName, WriterParameters parameters)
		{
			main_module.Write (fileName, parameters);
		}

		public void Write (Stream stream, WriterParameters parameters)
		{
			main_module.Write (stream, parameters);
		}
#endif

		public override string ToString ()
		{
			return this.FullName;
        }

        System.Collections.IDictionary m_annotations;
        System.Collections.IDictionary IAnnotationProvider.Annotations
        {
            get
            {
                if (m_annotations == null)
                    m_annotations = new System.Collections.Hashtable();
                return m_annotations;
            }
        }
	}
}
