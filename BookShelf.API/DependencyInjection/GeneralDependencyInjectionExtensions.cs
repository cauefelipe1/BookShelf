using System.Reflection;
using Microsoft.OpenApi.Models;
using Microsoft.VisualBasic;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BookShelf.API.DependencyInjection;

public static class GeneralDependencyInjectionExtensions
{
   /// <summary>
    /// Adds the all swagger dependencies into the <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/> instance.</param>
    public static void AddSwagger(this IServiceCollection services)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Description = "Inform a valid JWT token",
                Name = "Authorization",
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });

            options.AddXmlDocumentation();
        });
    }

    private static void AddXmlDocumentation(this SwaggerGenOptions options)
    {
        string path = AppContext.BaseDirectory;
        string[] xmlsToAdd =
        {
            $"{Assembly.GetEntryAssembly()!.GetName().Name}.xml",
            "Journal.Domain.xml",
            "Journal.Identity.xml"
        };

        foreach (string xml in xmlsToAdd)
        {
            string additional = Path.Combine(path, xml);

            if (File.Exists(additional))
            {
                options.IncludeXmlComments(additional);
            }
        }
    } 
}