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
    /// Creates associations between file types or node types in the project browser and
    /// icons in the resource service.
    /// </summary>
    /// <attribute name="resource" use="required">
    /// The name of a bitmap resource in the resource service.
    /// </attribute>
    /// <attribute name="language">
    /// This attribute is specified when a project icon association should be created.
    /// It specifies the language of the project types that use the icon.
    /// </attribute>
    /// <attribute name="extensions">
    /// This attribute is specified when a file icon association should be created.
    /// It specifies the semicolon-separated list of file types that use the icon.
    /// </attribute>
    /// <usage>Only in /Workspace/Icons</usage>
    /// <returns>
    /// An IconDescriptor object that exposes the attributes.
    /// </returns>
    public class IconDoozer : IDoozer
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
            return new IconDescriptor(codon);
        }
    }
}