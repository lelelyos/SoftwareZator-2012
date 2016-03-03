// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************




using VelerSoftware.SZC.VBNetParser.Ast;

namespace VelerSoftware.SZC.Debugger.Debugger
{
    public class GetValueException : DebuggerException
    {
        INode expression;
        string error;

        /// <summary> Expression that has caused this exception to occur </summary>
        public INode Expression
        {
            get { return expression; }
            set { expression = value; }
        }

        public string Error
        {
            get { return error; }
        }

        public override string Message
        {
            get
            {
                if (expression == null)
                {
                    return error;
                }
                else
                {
                    return error;
                    // return String.Format("Error evaluating \"{0}\": {1}", expression.PrettyPrint(), error);
                }
            }
        }

        public GetValueException(INode expression, string error)
            : base(error)
        {
            this.expression = expression;
            this.error = error;
        }

        public GetValueException(string error, System.Exception inner)
            : base(error, inner)
        {
            this.error = error;
        }

        public GetValueException(string errorFmt, params object[] args)
            : base(string.Format(errorFmt, args))
        {
            this.error = string.Format(errorFmt, args);
        }

        public GetValueException(string error)
            : base(error)
        {
            this.error = error;
        }
    }
}