
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
                .AddInMemoryClients(NetAuth.Server.InMemory.Clients.Get())
                .AddTestUsers(NetAuth.Server.InMemory.Users.Get())
                .AddInMemoryApiResources(NetAuth.Server.InMemory.Resources.GetApiResources())
                .AddInMemoryIdentityResources(NetAuth.Server.InMemory.Resources.GetIdentityResources())
                .AddExtensionGrantValidator<CustomGrantValidator>();
             */

            var builder = services.AddIdentityServer()
                .AddTemporarySigningCredential()
                .AddConfigurationStore(Configuration.GetSection("MongoDbRepository"))
                .AddOperationalStore(Configuration.GetSection("MongoDbRepository"));
            // Stores
            //services.AddTransient<IClientStore, NetAuth.Server.Mongo.Stores.ClientStore>();
            //services.AddTransient<IResourceStore, NetAuth.Server.Mongo.Stores.ResourceStore>();
            //services.AddTransient<IPersistedGrantStore, NetAuth.Server.Mongo.Stores.PersistedGrantStore>();
            
            services.AddTransient<IMongoRepository, MongoRepository>();
            services.AddTransient<IProfileService, NetAuth.Server.Mongo.Services.ProfileService>();
            //services.AddTransient<IResourceOwnerPasswordValidator, NetAuth.Server.ResourceOwnerPasswordValidator>();
            //services.AddTransient<IPasswordHasher<NetAuth.Models.User>, PasswordHasher<NetAuth.Models.User>>();

            services.AddMvc();

            services.AddTransient<NetAuth.Server.Quickstart.Login.LoginService>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            //loggerFactory.AddConsole(LogLevel.Debug);
            //loggerFactory.AddDebug(LogLevel.Debug);
            InitializeDatabase(app);

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
                    foreach (var client in NetAuth.Configuration.Juschubut.Clients())
                    {
                        context.Clients.InsertOne(client.ToDocument());
                    }
                }

                if (context.IdentityResources.Count(_ => true) == 0)
                {
                    foreach (var resource in NetAuth.Configuration.Juschubut.IdentityResources())
                    {
                        context.IdentityResources.InsertOne(resource.ToDocument());
                    }
                }

                if (context.ApiResources.Count(_ => true) == 0)
                {
                    foreach (var resource in NetAuth.Configuration.Juschubut.ApiResources())
                    {
                        context.ApiResources.InsertOne(resource.ToDocument());
                    }
                }
            }
        }
    }
}