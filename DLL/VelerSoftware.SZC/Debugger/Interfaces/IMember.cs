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
using System.Collections.Generic;

namespace VelerSoftware.SZC.Debugger.Interfaces
{
    public interface IMember : IEntity, ICloneable
    {
        /// <summary>
        /// Declaration region of the member (without body!)
        /// </summary>
        DomRegion Region
        {
            get;
        }

        /// <summary>
        /// Gets/Sets the declaring type reference (declaring type incl. type arguments).
        /// Never returns null.
        /// If the property is set to null (e.g. when this is not a specialized member),
        /// it should return the default type reference to the <see cref="DeclaringType"/>.
        /// </summary>
        IReturnType DeclaringTypeReference
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the generic member this member is based on.
        /// Returns null if this is not a specialized member.
        /// Specialized members are the result of overload resolution with type substitution.
        /// </summary>
        IMember GenericMember
        {
            get;
        }

        /// <summary>
        /// Creates a copy of this member with its GenericMember property set to this member.
        /// Use this method to create copies of a member that should be regarded as the "same member"
        /// for refactoring purposes.
        /// </summary>
        IMember CreateSpecializedMember();

        IReturnType ReturnType
        {
            get;
            set;
        }

        IList<ExplicitInterfaceImplementation> InterfaceImplementations
        {
            get;
        }
    }
}