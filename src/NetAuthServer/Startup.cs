
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NetAuthServer.Models;
using NetAuthServer.Services;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using IdentityServer4.Validation;
using CustomGrantValidator = NetAuthServer.Extensions.CustomGrantValidator;
using Microsoft.AspNetCore.Identity;

namespace NetAuthServer
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
                .AddInMemoryIdentityResources(NetAuthServer.Configuration.Resources.Get())
                .AddExtensionGrantValidator<CustomGrantValidator>();

            services.AddTransient<IRepository, MongoDbRepository>();
            services.AddTransient<IClientStore, MongoDbClientStore>();
            services.AddTransient<IProfileService, MongoDbProfileService>();
            services.AddTransient<IResourceOwnerPasswordValidator, MongoDbResourceOwnerPasswordValidator>();
            services.AddTransient<IPasswordHasher<MongoDbUser>, PasswordHasher<MongoDbUser>>();
            services.Configure<MongoDbRepositoryConfiguration>(Configuration.GetSection("MongoDbRepository"));

            services.AddMvc();

            services.AddTransient<NetAuthServer.Quickstart.Login.LoginService>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Debug);
            loggerFactory.AddDebug(LogLevel.Debug);

            app.UseDeveloperExceptionPage();

            app.UseIdentityServer();

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}