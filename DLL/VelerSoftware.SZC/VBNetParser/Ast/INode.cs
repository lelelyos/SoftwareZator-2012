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

namespace VelerSoftware.SZC.VBNetParser.Ast
{
    public interface INode
    {
        INode Parent
        {
            get;
            set;
        }

        List<INode> Children
        {
            get;
        }

        Location StartLocation
        {
            get;
            set;
        }

        Location EndLocation
        {
            get;
            set;
        }

        object UserData
        {
            get;
            set;
        }

        /// <summary>
        /// Visits all children
        /// </summary>
        /// <param name="visitor">The visitor to accept</param>
        /// <param name="data">Additional data for the visitor</param>
        /// <returns>The paremeter <paramref name="data"/></returns>
        object AcceptChildren(IAstVisitor visitor, object data);

        /// <summary>
        /// Accept the visitor
        /// </summary>
        /// <param name="visitor">The visitor to accept</param>
        /// <param name="data">Additional data for the visitor</param>
        /// <returns>The value the visitor returns after the visit</returns>
        object AcceptVisitor(IAstVisitor visitor, object data);
    }
}