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
    /// Creates a string.
    /// </summary>
    /// <attribute name="text" use="required">
    /// The string to return.
    /// </attribute>
    /// <returns>
    /// The string specified by 'text', passed through the StringParser.
    /// </returns>
    public class StringDoozer : IDoozer
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
            return StringParser.Parse(codon.Properties["text"]);
        }
    }
}