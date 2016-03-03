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
using System.Collections;

namespace VelerSoftware.SZC.Debugger.Core
{
    /// <summary>
    /// This doozer lazy-loads another doozer when it has to build an item.
    /// It is used internally to wrap doozers specified in addins.
    /// </summary>
    public class LazyLoadDoozer : IDoozer
    {
        AddIn addIn;
        string name;
        string className;

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string ClassName
        {
            get
            {
                return className;
            }
        }

        public LazyLoadDoozer(AddIn addIn, Properties properties)
        {
            this.addIn = addIn;
            this.name = properties["name"];
            this.className = properties["class"];
        }

        /// <summary>
        /// Gets if the doozer handles codon conditions on its own.
        /// If this property return false, the item is excluded when the condition is not met.
        /// </summary>
        public bool HandleConditions
        {
            get
            {
                IDoozer doozer = (IDoozer)addIn.CreateObject(className);
                if (doozer == null)
                {
                    return false;
                }
                AddInTree.Doozers[name] = doozer;
                return doozer.HandleConditions;
            }
        }

        public object BuildItem(object caller, Codon codon, ArrayList subItems)
        {
            IDoozer doozer = (IDoozer)addIn.CreateObject(className);
            if (doozer == null)
            {
                return null;
            }
            AddInTree.Doozers[name] = doozer;
            return doozer.BuildItem(caller, codon, subItems);
        }

        public override string ToString()
        {
            return String.Format("[LazyLoadDoozer: className = {0}, name = {1}]",
                                 className,
                                 name);
        }
    }
}