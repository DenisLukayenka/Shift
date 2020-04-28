using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shift.Services.Contexts;
using Shift.Services.Managers.User;
using Shift.Services.Providers.Token;
using Shift.Services.Services.Handler;
using Shift.Services.Services.Menu;
using Shift.Services.Services.Repositories;
using Shift.Services.Services.RequestProcessor;

namespace Shift.Web.ServicesExtensions
{
	public static class ServiceExtensions
	{
		public static void ConfigureRepositoryWrapper(this IServiceCollection services)
		{
			services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
		}

		public static void ConfigureServices(this IServiceCollection services)
		{
			services.AddTransient<IMenuService, MenuService>();
			services.AddTransient<IRequestProcessorAsync, RequestProcessor>();
			services.AddTransient<IRequestHandler, GenericRequestHandler>();
			services.AddTransient<ITokenProvider, JwtTokenProvider>();
			services.AddTransient<IUserManagerAsync, UserManager>();
		}

		public static void ConfigureSqlServerDbContext(this IServiceCollection services, IConfiguration config) 
		{
			var connectionString = config.GetConnectionString("sqlServerDefault");

			services.AddDbContext<CoreContext>(o => o.UseSqlServer(connectionString));
		}
		
	}
}
