using System.Linq;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Core.Libs.Service
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        // private const string IdTokenName = "Token";
        private readonly IApiVersionDescriptionProvider _provider;
        private readonly IOptions<SwaggerConfig> _config;

        public ConfigureSwaggerOptions(
            IApiVersionDescriptionProvider provider,
            IOptions<SwaggerConfig> config)
        {
            _provider = provider;
            _config = config;
        }

        public void Configure(SwaggerGenOptions options)
        {
            // add a swagger document for each discovered API version
            // note: you might choose to skip or document deprecated API versions differently
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                var info = new OpenApiInfo()
                {
                    Title = _config.Value.Title,
                    Version = description.ApiVersion.ToString(),
                    Description = _config.Value.Description
                };

                if (description.IsDeprecated)
                {
                    info.Description += " This API version has been deprecated.";
                }


                options.SwaggerDoc(description.GroupName, info);

                if (description.ApiVersion.MajorVersion == 1
                   && description.ApiVersion.MinorVersion == 0)
                {
                    // TODO: Implement Authentication Function 
                }

                if (description.ApiVersion.MajorVersion == 2
                    && description.ApiVersion.MinorVersion == 0)
                {
                    // TODO: Implement Authentication Function 
                }
            }
        }
    }

    public class SwaggerDefaultValues : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var apiDescription = context.ApiDescription;
            operation.Deprecated |= apiDescription.IsDeprecated();

            if (operation.Parameters == null)
                return;

            // REF: https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/412
            // REF: https://github.com/domaindrivendev/Swashbuckle.AspNetCore/pull/413
            foreach (var parameter in operation.Parameters)
            {
                var description = apiDescription.ParameterDescriptions.First(p => p.Name == parameter.Name);
                if (parameter.Description == null)
                {
                    parameter.Description = description.ModelMetadata?.Description;
                }

                if (parameter.Schema.Default == null && description.DefaultValue != null)
                {
                    parameter.Schema.Default = new OpenApiString(description.DefaultValue.ToString());
                }

                parameter.Required |= description.IsRequired;
            }
        }
    }
}