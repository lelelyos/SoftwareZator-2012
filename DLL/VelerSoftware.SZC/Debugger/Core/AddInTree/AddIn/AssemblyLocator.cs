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
using System.Reflection;

namespace VelerSoftware.SZC.Debugger.Core
{
    // Based on http://ayende.com/Blog/archive/2006/05/22/SolvingTheAssemblyLoadContextProblem.aspx
    // This class ensures that assemblies loaded into the LoadFrom context are also available
    // in the Load context.
    internal static class AssemblyLocator
    {
        static Dictionary<string, Assembly> assemblies = new Dictionary<string, Assembly>();
        static bool initialized;

        public static void Init()
        {
            lock (assemblies)
            {
                if (initialized)
                    return;
                initialized = true;
                AppDomain.CurrentDomain.AssemblyLoad += CurrentDomain_AssemblyLoad;
                AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            }
        }

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            lock (assemblies)
            {
                Assembly assembly = null;
                assemblies.TryGetValue(args.Name, out assembly);
                return assembly;
            }
        }

        private static void CurrentDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
        {
            Assembly assembly = args.LoadedAssembly;
            lock (assemblies)
            {
                assemblies[assembly.FullName] = assembly;
            }
        }
    }
}