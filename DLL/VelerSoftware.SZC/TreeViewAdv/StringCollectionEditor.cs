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
using System.ComponentModel.Design;

namespace VelerSoftware.SZC.TreeViewAdv
{
    public class StringCollectionEditor : CollectionEditor
    {
        public StringCollectionEditor(Type type)
            : base(type)
        {
        }

        protected override Type CreateCollectionItemType()
        {
            return typeof(string);
        }

        protected override object CreateInstance(Type itemType)
        {
            return "";
        }
    }
}