// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************




using System.Collections.Generic;

namespace VelerSoftware.SZC.Debugger.Interfaces
{
    public interface ICompilationUnit : IFreezable
    {
        string FileName
        {
            get;
            set;
        }

        bool ErrorsDuringCompile
        {
            get;
            set;
        }

        object Tag
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the main using scope of the compilation unit.
        /// That scope usually represents the root namespace.
        /// </summary>
        IUsingScope UsingScope
        {
            get;
        }

        IList<IAttribute> Attributes
        {
            get;
        }

        IList<IClass> Classes
        {
            get;
        }

        /// <summary>
        /// Returns the innermost class in which the carret currently is, returns null
        /// if the carret is outside any class boundaries.
        /// </summary>
        IClass GetInnermostClass(int caretLine, int caretColumn);
    }
}