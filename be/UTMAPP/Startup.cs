using System.Text;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
using UTMAPP.Models;

namespace UTMAPP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder().AddEnvironmentVariables().Build();
            var dbUser = configuration.GetSection("API_DATABASE_USER").Value;
            var dbPassword = configuration.GetSection("API_DATABASE_PASSWORD").Value;
            var dbHost = configuration.GetSection("API_DATABASE_HOST").Value;
            var dbName = configuration.GetSection("API_DATABASE_NAME").Value;
            var connString = $"Server={dbHost};Database={dbName};User={dbUser};Password={dbPassword};";

            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connString));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "UTMAPP REST API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "REST API V1");
            });
            app.UseMvc();
        }
    }
}
