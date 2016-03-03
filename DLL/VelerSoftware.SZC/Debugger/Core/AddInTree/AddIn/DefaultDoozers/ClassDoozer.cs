// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************




using System.Collections;

namespace VelerSoftware.SZC.Debugger.Core
{
    /// <summary>
    /// Creates object instances by invocating a type's parameterless constructor
    /// via System.Reflection.
    /// </summary>
    /// <attribute name="class" use="required">
    /// The fully qualified type name of the class to create an instace of.
    /// </attribute>
    /// <usage>Everywhere where objects are expected.</usage>
    /// <returns>
    /// Any kind of object.
    /// </returns>
    public class ClassDoozer : IDoozer
    {
        /// <summary>
        /// Gets if the doozer handles codon conditions on its own.
        /// If this property return false, the item is excluded when the condition is not met.
        /// </summary>
        public bool HandleConditions
        {
            get
            {
                return false;
            }
        }

        public object BuildItem(object caller, Codon codon, ArrayList subItems)
        {
            return codon.AddIn.CreateObject(codon.Properties["class"]);
        }
    }
}