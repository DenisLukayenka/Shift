using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shift.Services.Services.Handler;
using Shift.Services.Services.Menu;
using Shift.Services.Services.RequestProcessor;

namespace Shift.Web
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy",
					builder => builder.AllowAnyOrigin()
						.AllowAnyMethod()
						.AllowAnyHeader());
			});


			services.AddControllersWithViews()
				.AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

			services.AddSpaStaticFiles(configuration =>
			{
				configuration.RootPath = "ClientApp/dist";
			});

			this.RegisterServices(services);
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
			}

			app.UseCors("CorsPolicy");

			app.UseStaticFiles();
			if (!env.IsDevelopment())
			{
				app.UseSpaStaticFiles();
			}

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller}/{action=Index}/{id?}");
			});

			app.UseSpa(spa =>
			{
				spa.Options.SourcePath = "ClientApp";

				if (env.IsDevelopment())
				{
					spa.UseAngularCliServer(npmScript: "start");
				}
			});
		}

		private void RegisterServices(IServiceCollection services)
		{
			services.AddTransient<IMenuService, MenuService>();
			services.AddTransient<IRequestProcessorAsync, RequestProcessor>();
			services.AddTransient<IRequestHandler, GenericRequestHandler>();
		}
	}
}
