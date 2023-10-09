using System;

namespace ShipmentAPI
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class CustomSwaggerAttribute : Attribute
    {
        public string Description { get; }
        public string ParameterName { get; }
        public string ParameterValue { get; }


        public CustomSwaggerAttribute(string description, string paramName, string paramValue)
        {
            Description = description;
            ParameterName = paramName;
            ParameterValue = paramValue;
        }
    }

}
