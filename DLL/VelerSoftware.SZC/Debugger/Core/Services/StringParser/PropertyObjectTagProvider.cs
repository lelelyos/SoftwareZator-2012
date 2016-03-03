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
using System.Reflection;

namespace VelerSoftware.SZC.Debugger.Core
{
    /// <summary>
    /// Provides properties by using Reflection on an object.
    /// </summary>
    public sealed class PropertyObjectTagProvider : IStringTagProvider
    {
        readonly object obj;

        public PropertyObjectTagProvider(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");
            this.obj = obj;
        }

        public string ProvideString(string tag, StringTagPair[] customTags)
        {
            Type type = obj.GetType();
            PropertyInfo prop = type.GetProperty(tag);
            if (prop != null)
            {
                return prop.GetValue(obj, null).ToString();
            }
            FieldInfo field = type.GetField(tag);
            if (field != null)
            {
                return field.GetValue(obj).ToString();
            }
            return null;
        }
    }
}