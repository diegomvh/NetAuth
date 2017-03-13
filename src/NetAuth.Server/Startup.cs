
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using IdentityServer4.Services;
using MongoDB.Driver;
using IdentityServer4.MongoDB.Mappers;
using IdentityServer4.MongoDB.Interfaces;
using NetAuth.Server.Mongo;
using NetAuth.Server.Mongo.Services;

namespace NetAuth.Server
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            Environment = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        
        private readonly IHostingEnvironment Environment;
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            /*
            services.AddIdentityServer()
                .AddTemporarySigningCredential()
                .AddInMemoryClients(NetAuth.Server.Configuration.Custom.Clients())
                .AddTestUsers(NetAuth.Server.Configuration.Custom.TestUsers())
                .AddInMemoryApiResources(NetAuth.Server.Configuration.Custom.ApiResources())
                .AddInMemoryIdentityResources(NetAuth.Server.Configuration.Custom.IdentityResources())
                .AddExtensionGrantValidator<CustomGrantValidator>();
            */
            
            var builder = services.AddIdentityServer()
                .AddTemporarySigningCredential()
                .AddInMemoryClients(NetAuth.Server.Configuration.Juschubut.Clients())
                .AddInMemoryApiResources(NetAuth.Server.Configuration.Juschubut.ApiResources())
                //.AddConfigurationStore(Configuration.GetSection("MongoDbRepository"))
                //.AddOperationalStore(Configuration.GetSection("MongoDbRepository"));
                .AddTestUsers(NetAuth.Server.Configuration.Juschubut.TestUsers());
            
            services.AddTransient<IMongoRepository, MongoRepository>();
            //services.AddTransient<IProfileService, ProfileService>();
            //services.AddTransient<IdentityServer4.Validation.IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();
            //services.AddTransient<IPasswordHasher<NetAuth.Models.User>, PasswordHasher<NetAuth.Models.User>>();

            services.AddMvc();

            services.AddTransient<NetAuth.Server.Quickstart.Login.LoginService>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            //loggerFactory.AddConsole(LogLevel.Debug);
            //loggerFactory.AddDebug(LogLevel.Debug);
            //InitializeDatabase(app);

            app.UseDeveloperExceptionPage();

            app.UseIdentityServer();

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<IConfigurationRepository>();
                if (context.Clients.Count(_ => true) == 0)
                {
                    foreach (var client in NetAuth.Server.Configuration.Juschubut.Clients())
                    {
                        context.Clients.InsertOne(client.ToDocument());
                    }
                }

                if (context.IdentityResources.Count(_ => true) == 0)
                {
                    foreach (var resource in NetAuth.Server.Configuration.Juschubut.IdentityResources())
                    {
                        context.IdentityResources.InsertOne(resource.ToDocument());
                    }
                }

                if (context.ApiResources.Count(_ => true) == 0)
                {
                    foreach (var resource in NetAuth.Server.Configuration.Juschubut.ApiResources())
                    {
                        context.ApiResources.InsertOne(resource.ToDocument());
                    }
                }
            }
        }
    }
}