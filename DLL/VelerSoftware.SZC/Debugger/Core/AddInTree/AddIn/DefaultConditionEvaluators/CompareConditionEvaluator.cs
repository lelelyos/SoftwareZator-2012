﻿// *****************************************************************************
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
    /// Compares two strings.
    /// The strings are passed through the StringParser, so it is possible to compare
    /// SharpDevelop properties.<br/>
    /// Useful if you want to run a command only when a setting is active to prevent
    /// loading your addin if that setting isn't set.
    /// </summary>
    /// <attribute name="string">
    /// The first string.
    /// </attribute>
    /// <attribute name="equals">
    /// The second string.
    /// </attribute>
    /// <attribute name="comparisonType">
    /// The mode of the comparison: a field of the System.StringComparison enumeration. The default is
    /// 'OrdinalIgnoreCase'.
    /// </attribute>
    /// <example title="Check the value of a property in the PropertyService">
    /// &lt;Condition name = "Compare" string = "${property:SharpDevelop.FiletypesRegisterStartup}" equals = "True"&gt;
    /// </example>
    public class CompareConditionEvaluator : IConditionEvaluator
    {
        public bool IsValid(object caller, Condition condition)
        {
            string comparisonTypeText = condition.Properties["comparisonType"];
            StringComparison comparisonType;
            if (string.IsNullOrEmpty(comparisonTypeText))
                comparisonType = StringComparison.OrdinalIgnoreCase;
            else
                comparisonType = (StringComparison)Enum.Parse(typeof(StringComparison), comparisonTypeText);

            return string.Equals(StringParser.Parse(condition.Properties["string"]),
                                 StringParser.Parse(condition.Properties["equals"]),
                                 comparisonType);
        }
    }
}