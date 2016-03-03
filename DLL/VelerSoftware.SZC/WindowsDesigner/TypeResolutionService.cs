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
using Microsoft.CSharp;
using Microsoft.VisualBasic;

namespace VelerSoftware.SZC.WindowsDesigner
{
    /// <summary>
    /// This service resolved the types and is required when using the
    /// CodeDomHostLoader
    /// </summary>
	public class TypeResolutionService : ITypeResolutionService
	{
        Hashtable ht = new Hashtable();

		public TypeResolutionService()
		{
		}

		public System.Reflection.Assembly GetAssembly(System.Reflection.AssemblyName name)
		{
			return GetAssembly(name, true);
		}
		public System.Reflection.Assembly GetAssembly(System.Reflection.AssemblyName name, bool throwOnErrors)
		{
			return Assembly.GetAssembly(typeof(Form));
		}
		public string GetPathOfAssembly(System.Reflection.AssemblyName name)
		{
			return null;
		}
		public Type GetType(string name)
		{
			return this.GetType(name, true);
		}
		public Type GetType(string name, bool throwOnError)
		{
			return this.GetType(name, throwOnError, false);
		}

        /// <summary>
        /// This method is called when dropping controls from the toolbox
        /// to the host that is loaded using CodeDomHostLoader. For
        /// simplicity we just go through System.Windows.Forms assembly
        /// </summary>
        public Type GetType(string name, bool throwOnError, bool ignoreCase)
        {
            if (name.Trim() != null)
			{
				bool ok = false;
				Type returnType = Type.GetType(name, false, ignoreCase);
				if (returnType != null)
				{
					ok = true;
					return returnType;
				}
                if (ok != true)
                {
                    Assembly[] assemblys = AppDomain.CurrentDomain.GetAssemblies();  
                    Type[] types;
                    foreach (Assembly an in assemblys)
                    {        
                        if (!an.IsDynamic)
                        { 
                            ok = false;
                            types = an.GetExportedTypes();
                            if (types != null)
                            {
                                foreach (Type t in types)
                                {
                                    if (name.Contains(",") && t.FullName == name.Split(',')[0])
                                    {
                                        ok = true;
                                        return t;
                                    }
                                    else
                                    {
                                        if (t.FullName == name)
                                        {
                                            ok = true;
                                            return t;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
				if (throwOnError)
				{
					//throw new ArgumentException();
				}                                                
				if (ok == false)
				{
					if (name != "")
                    {                
						throw new Exception("Unable to find the type '" + name + "'. Please make sure that all DLL required for this type are in your project's References.");
					}
				}
			}
            return null;
        }

		public void ReferenceAssembly(System.Reflection.AssemblyName name)
		{
            System.Reflection.Assembly.Load(name);
		}

	}// class
}// namespace
