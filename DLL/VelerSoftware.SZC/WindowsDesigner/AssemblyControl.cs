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
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Reflection;

namespace VelerSoftware.SZC.WindowsDesigner
{
    public class AssemblyControl
    {
        public AssemblyControl()
        {
        }

        /// <summary>
        /// Charge tous les types qui héritent de Control
        /// à partir de l'assembly passée en paramètre
        /// </summary>
        /// <param name="assembly">Assembly a explorer</param>
        /// <returns>Tableau de Type</returns>
        public Type[] LoadControlsFromAssembly(Assembly assembly)
        {
            Type[] exportedTypes;
            ArrayList t = new ArrayList();
            if (assembly != null)
            {
                try
                {
                    exportedTypes = assembly.GetExportedTypes();
                    for (int i = 0; i < exportedTypes.Length; i++)
                    {
                        if ((exportedTypes[i].IsSubclassOf(typeof(AxHost)) == false) && (exportedTypes[i].IsSubclassOf(typeof(Component))))
                        {
                            t.Add(exportedTypes[i]);
                        }
                    }
                }
                catch { }
            }
            return (Type[])t.ToArray(typeof(Type));
        }


        /// <summary>
        /// Charge tous les types
        /// à partir de l'assembly passée en paramètre
        /// </summary>
        /// <param name="assembly">Assembly a explorer</param>
        /// <returns>Tableau de Type</returns>
        public Type[] LoadTypesFromAssembly(Assembly assembly)
        {
            Type[] exportedTypes;
            ArrayList t = new ArrayList();
            if (assembly != null)
            {
                exportedTypes = assembly.GetTypes();
                for (int i = 0; i < exportedTypes.Length; i++)
                {
                    t.Add(exportedTypes[i]);
                }
            }
            return (Type[])t.ToArray(typeof(Type));
        }

    }
}
