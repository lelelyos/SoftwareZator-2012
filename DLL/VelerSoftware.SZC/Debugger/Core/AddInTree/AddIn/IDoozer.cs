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
    /// Interface for classes that can build objects out of codons.
    /// </summary>
    /// <remarks>http://en.wikipedia.org/wiki/Fraggle_Rock#Doozers</remarks>
    public interface IDoozer
    {
        /// <summary>
        /// Gets if the doozer handles codon conditions on its own.
        /// If this property return false, the item is excluded when the condition is not met.
        /// </summary>
        bool HandleConditions { get; }

        /// <summary>
        /// Construct the item.
        /// </summary>
        /// <param name="caller">The caller passed to <see cref="AddInTree.BuildItem"/>.</param>
        /// <param name="codon">The codon to build.</param>
        /// <param name="subItems">The list of objects created by (other) doozers for the sub items.</param>
        /// <returns>The constructed item.</returns>
        object BuildItem(object caller, Codon codon, ArrayList subItems);
    }
}