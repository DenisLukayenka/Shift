using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Shift.DI.Extensions
{
	using Shift.Repository.Database;
	using Shift.Repository.Repositories;
	using Shift.Repository.Repositories.Implementations;
	using Shift.Repository.Repositories.Interfaces;
	using Shift.Services.Managers.Journals.GJournals;
	using Shift.Services.Managers.Journals.UJournals;
	using Shift.Services.Managers.User;
	using Shift.Services.Providers.Token;
	using Shift.Services.Services.Menu;

	public static class ServicesExtensions
	{
		public static void ConfigureSqlServerDbContext(this IServiceCollection services, IConfiguration config)
		{
			var connectionString = config.GetConnectionString("sqlServerDefault");
			services.AddDbContext<CoreContext>(o => o.UseSqlServer(connectionString));
			services.AddScoped<CoreContext>();
		}

		public static void ConfigureRepositoryWrapper(this IServiceCollection services)
		{
			services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

			services.AddScoped<IEmployeeRepository, EmployeeRepository>();
			services.AddScoped<IGJournalRepository, GJournalRepository>();
			services.AddScoped<IGraduateRepository, GraduateRepository>();
			services.AddScoped<IRoleRepository, RoleRepository>();
			services.AddScoped<IUJournalRepository, UJournalRepository>();
			services.AddScoped<IUndergraduateRepository, UndergraduateRepository>();
			services.AddScoped<IUserRepository, UserRepository>();
		}

		public static void ConfigureServices(this IServiceCollection services)
		{
			services.AddTransient<IMenuService, MenuService>();
			services.AddTransient<ITokenProvider, JwtTokenProvider>();
			services.AddTransient<IUserManager, UserManager>();
			services.AddTransient<IUJournalManager, UJournalManager>();
			services.AddTransient<IGJournalManager, GJournalManager>();
		}

		public static void ConfigureJwtAuth(this IServiceCollection services)
		{
			services.AddAuthentication(opt =>
			{
				opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(opt =>
			{
				opt.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,

					ValidIssuer = "http://localhost:4200",
					ValidAudience = "http://localhost:50280",
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("qwertgdhgy@1gfdhhhfd11")),
				};
			});
		}
	}
}
