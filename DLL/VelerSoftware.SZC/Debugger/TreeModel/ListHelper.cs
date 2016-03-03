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

namespace VelerSoftware.SZC.Debugger.TreeModel.Visualizer.Utils
{
    /// <summary>
    /// ListHelper wraps System.Collection.Generic.List methods to return the original list,
    /// instead of returning 'void', so we can write eg. list.Sorted().First()
    /// </summary>
    public static class ListHelper
    {
        public static List<T> Sorted<T>(this List<T> list, IComparer<T> comparer)
        {
            list.Sort(comparer);
            return list;
        }

        public static List<T> Sorted<T>(this List<T> list)
        {
            list.Sort();
            return list;
        }

        public static List<T> ToList<T>(this T singleItem)
        {
            var newList = new List<T>();
            newList.Add(singleItem);
            return newList;
        }
    }
}