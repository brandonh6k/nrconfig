﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NewRelicConfigManager.Rendering
{
    /// <summary>
    /// Class for New Relic-compatible XML output of the exactMethodMatcher element.
    /// </summary>
    public class ExactMethodMatcher
    {
        [XmlAttribute(AttributeName="methodName")]
        public string MethodName { get; set; }
        [XmlAttribute(AttributeName="parameters")]
        public string ParameterTypes { get; set; }

        public ExactMethodMatcher()
        {

        }

        public ExactMethodMatcher(string methodName, string[] parameterTypes)
        {
            this.MethodName = methodName;
            if (parameterTypes != null && parameterTypes.Any())
            {
                this.ParameterTypes = string.Join(",", parameterTypes);
            }
        }

        public override bool Equals(object obj)
        {
            var other = obj as ExactMethodMatcher;
            if (other == null)
            {
                return false;
            }
            else
            {
                return this.MethodName == other.MethodName && this.ParameterTypes == other.ParameterTypes;
            }
        }

        public override int GetHashCode()
        {
            return (251 * (MethodName ?? "").GetHashCode())
                + (ParameterTypes ?? "").GetHashCode();
        }
    }
}
