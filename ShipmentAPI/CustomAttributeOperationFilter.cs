using Microsoft.Build.Evaluation;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace ShipmentAPI
{
    public class CustomAttributeOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var customAttributes = context.MethodInfo.GetCustomAttributes<CustomSwaggerAttribute>().ToList();

            if (customAttributes.Any())
            {
                foreach (var customAttribute in customAttributes)
                {
                    operation.Description += $" {customAttribute.Description}";

                    // Add custom parameter and value to the operation's parameters
                    operation.Parameters.Add(new OpenApiParameter
                    {
                        Name = customAttribute.ParameterName,
                        In = ParameterLocation.Header, // Adjust location as needed
                        Description = customAttribute.ParameterValue,
                        Required = false // Adjust as needed
                    });
                }
            }
        }
    }

}
