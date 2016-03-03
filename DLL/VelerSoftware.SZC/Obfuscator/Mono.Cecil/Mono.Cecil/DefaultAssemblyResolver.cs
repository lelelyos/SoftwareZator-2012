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
using System.Collections.Generic;

namespace Mono.Cecil {

	public static class GlobalAssemblyResolver {

		public static readonly DefaultAssemblyResolver Instance = new DefaultAssemblyResolver ();
	}

	public class DefaultAssemblyResolver : BaseAssemblyResolver {

        public readonly IDictionary<string, AssemblyDefinition> AssemblyCache;

		public DefaultAssemblyResolver ()
		{
            AssemblyCache = new Dictionary<string, AssemblyDefinition>();
		}

		public override AssemblyDefinition Resolve (AssemblyNameReference name)
		{
			if (name == null)
				throw new ArgumentNullException ("name");

            AssemblyDefinition assembly;
            if (AssemblyCache.TryGetValue(name.FullName, out assembly))
				return assembly;

			assembly = base.Resolve (name);
            if (assembly != null)
                AssemblyCache[name.FullName] = assembly;

			return assembly;
		}

		protected void RegisterAssembly (AssemblyDefinition assembly)
		{
			if (assembly == null)
				throw new ArgumentNullException ("assembly");

			var name = assembly.Name.FullName;
            if (AssemblyCache.ContainsKey(name))
				return;

            AssemblyCache[name] = assembly;
		}
	}
}
