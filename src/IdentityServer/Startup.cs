
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using IdentityServer4.Validation;
using CustomGrantValidator = NetAuth.IdentityServer.Extensions.CustomGrantValidator;
using Microsoft.AspNetCore.Identity;
using MongoDB.Driver;
using IdentityServer4.Models;

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
            var builder = services.AddIdentityServer()
                .AddTemporarySigningCredential()
                .AddInMemoryClients(NetAuth.IdentityServer.InMemory.Clients.Get())
                .AddTestUsers(NetAuth.IdentityServer.InMemory.Users.Get())
                .AddInMemoryApiResources(NetAuth.IdentityServer.InMemory.Resources.GetApi())
                .AddInMemoryIdentityResources(NetAuth.IdentityServer.InMemory.Resources.GetIdentity());
                //.AddExtensionGrantValidator<CustomGrantValidator>();

            services.AddSingleton<IMongoDatabase>(this.CreateMongoDatabase());
            services.AddTransient<NetAuth.Mongo.Context>();
            // Stores
            //services.AddTransient<IClientStore, NetAuth.IdentityServer.Mongo.Stores.ClientStore>();
            //services.AddTransient<IResourceStore, NetAuth.IdentityServer.Mongo.Stores.ResourceStore>();
            services.AddTransient<IPersistedGrantStore, NetAuth.IdentityServer.Mongo.Stores.PersistedGrantStore>();
            
            services.AddTransient<IProfileService, NetAuth.IdentityServer.Mongo.Services.ProfileService>();
            //services.AddTransient<IResourceOwnerPasswordValidator, NetAuth.IdentityServer.Mongo.ResourceOwnerPasswordValidator>();
            services.AddTransient<IPasswordHasher<NetAuth.Mongo.Models.User>, PasswordHasher<NetAuth.Mongo.Models.User>>();

            services.AddMvc();

            services.AddTransient<NetAuth.IdentityServer.Quickstart.Login.LoginService>();
        }

        public IMongoDatabase CreateMongoDatabase() {
            var config = Configuration.GetSection("MongoDbRepository");
            var client = new MongoClient(config.GetValue<string>("ConnectionString"));
            return client.GetDatabase(config.GetValue<string>("DatabaseName"));
        }
        
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            //loggerFactory.AddConsole(LogLevel.Debug);
            //loggerFactory.AddDebug(LogLevel.Debug);
            app.UseDeveloperExceptionPage();

            app.UseIdentityServer();

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}