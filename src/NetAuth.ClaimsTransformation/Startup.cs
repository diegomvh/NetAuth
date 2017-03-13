using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NetAuth.ClaimsTransformation.Authorizations;

namespace NetAuth.ClaimsTransformation
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options=>
            {
                // this defines a CORS policy called "default"
                options.AddPolicy("default", policy =>
                {
                    policy.WithOrigins("http://localhost:5003")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            // Add framework services.
            services.AddMvcCore()
                .AddAuthorization(
                    options => {
                        //Custom
                        options.AddPolicy("Over21",
                            policy => policy.Requirements.Add(new MinimumAgeRequirement(21)));
                        //Function
                        options.AddPolicy("BadgeEntry",
                            policy => policy.RequireAssertion(context =>
                                context.User.HasClaim(c =>
                                    (c.Type == ClaimTypes.Role ||
                                    c.Type == ClaimTypes.Country)
                                    && c.Issuer == "https://microsoftsecurity")));
                })
                .AddJsonFormatters();
            services.AddSingleton<IAuthorizationHandler, MinimumAgeHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors("default");
            
            app.UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
            {
                Authority = "http://localhost:5000",
                RequireHttpsMetadata = false,

                ApiName = "serconexcivil-api"
            });

            app.UseClaimsTransformation(o => new ClaimsTransformer().TransformAsync(o));
            app.UseMvc();
        }
    }
}
