using DataBaseFirst.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBaseFirst
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /*
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("SqlServerConnection");

            services.AddDbContext<dbpdvContext>(options =>
               options.UseSqlServer(connectionString));
          
            services.AddControllersWithViews();
        }
        */

        /// <summary>
        /// Este metodo registra uma DbContext subclasse chamada AppDbContext 
        /// como um servi�o com escopo no provedor de servi�os de aplicativo ASP.NET Core 
        /// (tamb�m conhecido como o cont�iner de inje��o de depend�ncia). O contexto � 
        /// configurado para usar o provedor de banco de dados SQL Server e ler� a cadeia de 
        /// conex�o da configura��o de ASP.NET Core. Normalmente, n�o importa onde a ConfigureServices 
        /// chamada AddDbContext � feita.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc();
            services.AddAuthorization();
            var connectionString = Configuration.GetConnectionString("SqlServerConnection");
            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(connectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
