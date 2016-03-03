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
    public interface IUsing : IFreezable
    {
        DomRegion Region
        {
            get;
        }

        IList<string> Usings
        {
            get;
        }

        bool HasAliases { get; }

        void AddAlias(string alias, IReturnType type);

        /// <summary>
        /// Gets the list of aliases. Can be null when there are no aliases!
        /// </summary>
        IDictionary<string, IReturnType> Aliases
        {
            get;
        }

        /// <summary>
        /// Returns a collection of possible types that could be meant when using this Import
        /// to search the type.
        /// Types with the incorrect type parameter count might be returned, but for each
        /// same using entry or alias entry at most one (the best matching) type should be returned.
        /// </summary>
        /// <returns>An IEnumerable with zero or more non-null return types.</returns>
        IEnumerable<IReturnType> SearchType(string partialTypeName, int typeParameterCount);

        string SearchNamespace(string partialNamespaceName);
    }
}