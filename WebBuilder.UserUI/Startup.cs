using System;
using System.Collections.Generic;
using Data.Abstract;
using Data.Concrete.DataAccesLayers;
using Data.Concrete.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebBuilder.Business.Concrete;
using WebBuilder.Business.Abstract.DataServices;
using System.Globalization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Localization;
using WebBuilder.Middleware;
using Microsoft.AspNetCore.Http;
using WebBuilder.Middleware.Middlewares;
using Microsoft.AspNetCore.Authentication.Cookies;

using System.Diagnostics;
using Data.Abstract.LanguageAbstracts;
using Data.Concrete.DataAccesLayers.LanguageDataAccesLayers;
using WebBuilder.Business.Abstract.LanguageDataServices;
using WebBuilder.Business.Concrete.LanguageDataServices;

namespace WebBuilder.UserUI
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
            services.AddControllersWithViews()
                    .AddRazorRuntimeCompilation();
            services.AddSession();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = "/backofis/Account/Login/";
        });
            services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
            #region DAL Resolver
            services.AddScoped<ILanguageDAL, EfLanguageDAL>();
            services.AddScoped<ISliderDAL, EfSliderDAL>();
            services.AddScoped<ISliderImageDAL, EfSliderImageDAL>();
            services.AddScoped<IMenuDAL, EfMenuDAL>();
            services.AddScoped<ICategoryDAL, EfCategoryDAL>();
            services.AddScoped<IProductImageDAL, EfProductImageDAL>();
            services.AddScoped<IProductDAL, EfProductDAL>();
            services.AddScoped<IContactDAL, EfContactDAL>();
            services.AddScoped<IContactInformationDAL, EfContactInformationDAL>();
            services.AddScoped<IProjectDAL, EfProjectDAL>();
            services.AddScoped<IServiceDAL, EfServiceDAL>();
            services.AddScoped<IGlobalTextDataDAL, EfGlobalTextDataDAL>();
            services.AddScoped<IGlobalTextDataLanguageDAL, EfGlobalTextDataLanguageDAL>();
            #endregion
            #region Menager Resolver
            services.AddScoped<ILanguageService, LanguageMenager>();
            services.AddScoped<ISliderService, SliderMenager>();
            services.AddScoped<ISliderImageService, SliderImageMenager>();
            services.AddScoped<IMenuService, MenuMenager>();
            services.AddScoped<ICategoryService, CategoryMenager>();
            services.AddScoped<IProductImageService, ProductImageMenager>();
            services.AddScoped<IProductService, ProductMenager>();
            services.AddScoped<IContactService, ContactMenager>();
            services.AddScoped<IContactInformationService, ContactInformationMenager>();
            services.AddScoped<IProjectService, ProjectMenager>();
            services.AddScoped<IServiceService, ServiceMenager>();
            services.AddScoped<IGlobalTextDataService, GlobalTextDataMenager>();
            services.AddScoped<IGlobalTextDataLanguageService, GlobalTextDataLanguageMenager>();
            services.AddScoped<UiDataService>();
            #endregion
            services.AddDbContext<WebBuilderContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DeveloperMsSql")));
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
         
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var client = new WebBuilderContext())
                {
                    client.Database.EnsureDeleted();
                    client.Database.EnsureCreated();
                }
            }
            else
            {
                app.UseDeveloperExceptionPage();
                using (var client = new WebBuilderContext())
                {
                    client.Database.EnsureCreated();
                }
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();

            }
            app.UseAuthentication();
            app.UseSession(); 
            app.UseHttpsRedirection();
            app.UseStaticFiles();

           

            app.MapWhen(context => !isBackOfisRequest(context), appBuilder =>
            {
                appBuilder.UseRouting();
                appBuilder.UseAuthorization();
                appBuilder.UseWebBuilderMiddlewares();
                appBuilder.UseEndpoints(endpoints =>
                {

                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller}/{action}/{id?}",
                        defaults: new { culture = "tr-TR", controller = "Home", action = "Index" }
                        );
                });

            });
            app.MapWhen(context => isBackOfisRequest(context), appBuilder =>
            {
                appBuilder.UseRouting();
                appBuilder.UseAuthorization();
                appBuilder.UseMiddleware<BackofisLanguageMiddleware>();
                appBuilder.UseEndpoints(endpoints =>
                {

                    endpoints.MapAreaControllerRoute(
                       name: "backofis",
                       areaName: "backofis",
                       pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}",
                       defaults: new { controller = "Home", action = "Index" }
                       );
                });

            });
        }

        public bool isBackOfisRequest(HttpContext context)
        {
            
            if (context.Request.Path.StartsWithSegments("/backofis"))
            {
                Debug.WriteLine("Request Type: /backofis request");
                return true;
            }
            Debug.WriteLine("Request Type: normal request");

            return false;
        }
    }
}
