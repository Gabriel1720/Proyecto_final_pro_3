using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReflectionIT.Mvc.Paging;
using Proyecto_final_pro_3.Models;
using Microsoft.EntityFrameworkCore;
using Proyecto_final_pro_3.Services;

namespace Proyecto_final_pro_3
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DB_A64A4C_SuperMercadoContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("DefualtConnection")));

            services.AddScoped<IContextService, ContextService>();

            services.AddControllersWithViews();
            services.AddPaging();

            services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
            services.AddSession();
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
            app.UseSession(); 
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute("Admin", "Admin", "{controller=PerfilAdmin}/{action=Cuenta}/{id?}");
                endpoints.MapAreaControllerRoute("GestionProductos", "Admin", "{controller=GestionProductos}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute("Cliente", "Cliente", "{controller=PerfilCliente}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute("GestionPedidos", "Admin", "{controller=GestionPedidos}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute("PruebaCarrito", "Admin", "{controller=PruebaCarrito}/{action=Index}/{id?}");
            });
        }
    }
}
