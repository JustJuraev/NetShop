using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetShop.Models;
using NetShop.Repository.Interface;
using NetShop.Repository.Repository;
using NetShop.Service.Interfaces;
using NetShop.Service.Services;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetShop
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
			services.AddControllersWithViews();
			services.AddSession(o =>
			{
				o.IdleTimeout = TimeSpan.FromMinutes(55);
			});
			var connection = Configuration["ConnectionStrings:ConnectionString"];
			var password = Configuration["ConnectionStrings:DbPassword"];

			var builder = new NpgsqlConnectionStringBuilder(connection)
			{
				Password = password
			};

            services.Configure<FormOptions>(options =>
            {
                // Set the limit to 128 MB
                options.MultipartBodyLengthLimit = 134217728;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
               options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
               options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
            });

            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(builder.ConnectionString));
			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<IProductPropertyRepository, ProductPropertyRepository>();
			services.AddScoped<ICategoryRepository, CategoryRepository>();
			services.AddScoped<IOrderRepository, OrderRepository>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IProductAddressRepository, ProductAddressRepository>();
			services.AddScoped<IRegionRepository, RegionRepository>();
			services.AddScoped<IProductService, ProductService>();
			services.AddScoped<IProductPropertyService, ProductPropertyService>();
			services.AddScoped<ICategoryService, CategoryService>();
			services.AddScoped<IOrderService, OrderService>();
			services.AddScoped<IAccountService, AccountService>();
			services.AddScoped<IProductAddressService, ProductAddressService>();
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
			app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Product}/{action=Index}/{id?}");
			});
		}
	}
}
