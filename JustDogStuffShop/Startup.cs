using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using JustDogStuffShop.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace JustDogStuffShop
{
	public class Startup
    {
		private IConfigurationRoot _configurationRoot;

		public Startup(IHostingEnvironment hostingEnvironment)
		{
			_configurationRoot = new ConfigurationBuilder()
				.SetBasePath(hostingEnvironment.ContentRootPath)
				//.AddJsonFile("appsettings.json")
				.AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", true)
				.Build();
		}

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
			services.AddDbContext<AppDbContext>(options => options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection")));

			services.AddIdentity<IdentityUser, IdentityRole>()
				.AddEntityFrameworkStores<AppDbContext>();

			services.AddTransient<ICategoryRepository, CategoryRepository>();
			services.AddTransient<IProductRepository, ProductRepository>();
			services.AddTransient<IOrderRepository, OrderRepository>();

			//for working with our session and shopping cart
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddScoped(sp => ShoppingCart.GetCart(sp));
			services.AddMemoryCache();
			services.AddSession();

			services.AddMvc();
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseStatusCodePages();
			}
			else
			{
				app.UseExceptionHandler("/AppException");
			}

			app.UseStaticFiles();
			app.UseSession(); //for the session/shopping cart (must go before UseMvcWithDefaultRoute() or it won't work!)
			app.UseIdentity();
			//app.UseMvcWithDefaultRoute();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "categoryfilter",
					template: "Product/{action}/{category?}",
					defaults: new { Controller = "Product", action = "List" });

				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});

			DbInitializer.Seed(app);
        }
    }
}
