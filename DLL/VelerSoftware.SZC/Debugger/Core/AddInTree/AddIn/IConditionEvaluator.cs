// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************




namespace VelerSoftware.SZC.Debugger.Core
{
    /// <summary>
    /// Interface for classes that can evaluate conditions defined in the addin tree.
    /// </summary>
    public interface IConditionEvaluator
    {
        bool IsValid(object owner, Condition condition);
    }
}