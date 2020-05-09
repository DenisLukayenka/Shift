using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shift.DI.Extensions;

namespace Shift.DI
{
	public class RegisterDependencies
	{
		public static void InjectDependencies(IServiceCollection services, IConfiguration config)
		{
			services.ConfigureSqlServerDbContext(config);
			services.ConfigureRepositoryWrapper();
			services.ConfigureServices();
			services.ConfigureJwtAuth();
		}
	}
}
