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

namespace VelerSoftware.SZC.Debugger.Core
{
    public interface IOwnerState
    {
        System.Enum InternalState
        {
            get;
        }
    }

    /// <summary>
    /// Condition evaluator that compares the state of the caller/owner with a specified value.
    /// The caller/owner has to implement <see cref="IOwnerState"/>.
    /// </summary>
    public class OwnerStateConditionEvaluator : IConditionEvaluator
    {
        public bool IsValid(object caller, Condition condition)
        {
            if (caller is IOwnerState)
            {
                try
                {
                    System.Enum state = ((IOwnerState)caller).InternalState;
                    System.Enum conditionEnum = (System.Enum)Enum.Parse(state.GetType(), condition.Properties["ownerstate"]);

                    int stateInt = Int32.Parse(state.ToString("D"));
                    int conditionInt = Int32.Parse(conditionEnum.ToString("D"));

                    return (stateInt & conditionInt) > 0;
                }
                catch (Exception ex)
                {
                    throw new CoreException("can't parse '" + condition.Properties["state"] + "'. Not a valid value.", ex);
                }
            }
            return false;
        }
    }
}