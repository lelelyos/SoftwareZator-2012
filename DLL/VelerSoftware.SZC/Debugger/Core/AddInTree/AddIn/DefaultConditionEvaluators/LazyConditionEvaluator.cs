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
    /// <summary>
    /// Condition evaluator that lazy-loads another condition evaluator and executes it.
    /// </summary>
    public class LazyConditionEvaluator : IConditionEvaluator
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

        public LazyConditionEvaluator(AddIn addIn, Properties properties)
        {
            this.addIn = addIn;
            this.name = properties["name"];
            this.className = properties["class"];
        }

        public bool IsValid(object caller, Condition condition)
        {
            IConditionEvaluator evaluator = (IConditionEvaluator)addIn.CreateObject(className);
            if (evaluator == null)
            {
                return false;
            }
            AddInTree.ConditionEvaluators[name] = evaluator;
            return evaluator.IsValid(caller, condition);
        }

        public override string ToString()
        {
            return String.Format("[LazyLoadConditionEvaluator: className = {0}, name = {1}]",
                                 className,
                                 name);
        }
    }
}