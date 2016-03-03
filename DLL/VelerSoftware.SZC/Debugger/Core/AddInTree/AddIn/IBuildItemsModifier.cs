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
    /// When a <see cref="IDoozer">doozer</see> returns an object implementing
    /// this interface, the <see cref="Apply"/> method is called on the list of items
    /// that has been built.
    /// This interface can be used to support special <see cref="IDoozer">doozers</see>
    /// that do not simply build one item but want to modify the list of items built so far.
    /// Example use is the <see cref="IncludeDoozer"/> which uses this interface to return
    /// multiple items instead of one.
    /// </summary>
    public interface IBuildItemsModifier
    {
        void Apply(IList items);
    }
}