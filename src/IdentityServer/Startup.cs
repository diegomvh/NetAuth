
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using IdentityServer4.Services;
using MongoDB.Driver;
using IdentityServer4.MongoDB.Mappers;
using IdentityServer4.MongoDB.Interfaces;
using IdentityServer4.Validation;
using NetAuth.IdentityServer.Extensions;
using Microsoft.AspNetCore.Hosting.Internal;

namespace NetAuth.IdentityServer
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
                .AddInMemoryClients(NetAuth.IdentityServer.InMemory.Clients.Get())
                .AddTestUsers(NetAuth.IdentityServer.InMemory.Users.Get())
                .AddInMemoryApiResources(NetAuth.IdentityServer.InMemory.Resources.GetApiResources())
                .AddInMemoryIdentityResources(NetAuth.IdentityServer.InMemory.Resources.GetIdentityResources())
                .AddExtensionGrantValidator<CustomGrantValidator>();
             */

            var builder = services.AddIdentityServer()
                .AddTemporarySigningCredential()
                .AddConfigurationStore(Configuration.GetSection("MongoDbRepository"))
                .AddOperationalStore(Configuration.GetSection("MongoDbRepository"))
                .AddExtensionGrantValidator<CustomGrantValidator>();
            // Stores
            //services.AddTransient<IClientStore, NetAuth.IdentityServer.Mongo.Stores.ClientStore>();
            //services.AddTransient<IResourceStore, NetAuth.IdentityServer.Mongo.Stores.ResourceStore>();
            //services.AddTransient<IPersistedGrantStore, NetAuth.IdentityServer.Mongo.Stores.PersistedGrantStore>();
            
            services.AddTransient<IProfileService, NetAuth.IdentityServer.Mongo.Services.ProfileService>();
            services.AddTransient<IResourceOwnerPasswordValidator, NetAuth.IdentityServer.ResourceOwnerPasswordValidator>();
            //services.AddTransient<IPasswordHasher<NetAuth.Models.User>, PasswordHasher<NetAuth.Models.User>>();

            services.AddMvc();

            services.AddTransient<NetAuth.IdentityServer.Quickstart.Login.LoginService>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            //loggerFactory.AddConsole(LogLevel.Debug);
            //loggerFactory.AddDebug(LogLevel.Debug);
            InitializeDatabase(app);

            app.UseDeveloperExceptionPage();

            app.UseIdentityServer();
            app.UseIdentityServerMongoTokenCleanup(new ApplicationLifetime());

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<IConfigurationDbContext>();
                if (context.Clients.Count(_ => true) == 0)
                {
                    foreach (var client in NetAuth.IdentityServer.InMemory.Clients.Get())
                    {
                        context.Clients.InsertOne(client.ToDocument());
                    }
                }

                if (context.IdentityResources.Count(_ => true) == 0)
                {
                    foreach (var resource in NetAuth.IdentityServer.InMemory.Resources.GetIdentityResources())
                    {
                        context.IdentityResources.InsertOne(resource.ToDocument());
                    }
                }

                if (context.ApiResources.Count(_ => true) == 0)
                {
                    foreach (var resource in NetAuth.IdentityServer.InMemory.Resources.GetApiResources())
                    {
                        context.ApiResources.InsertOne(resource.ToDocument());
                    }
                }
            }
        }
    }
}