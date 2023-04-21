using AutoMapper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Pacagroup.Ecommerce.Services.WebApi.Modules.Features
{
    public static class FeatureExtensions
    {
        

        public static IServiceCollection AddFeature(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration) 
        {
            string myPolicy = "policyApiEcommerce";

            services.AddCors(options => options.AddPolicy(myPolicy, builder => builder.WithOrigins(configuration["Config:OriginCors"])
                                                                                        .AllowAnyHeader()
                                                                                        .AllowAnyMethod()));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

            return services;
        }
    }
}
