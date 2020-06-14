using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Shift.DI.Extensions
{
    using Shift.FileGenerator.UJournal;
    using Shift.Infrastructure.Models.SharedData;
	using Shift.Repository.Database;
	using Shift.Repository.Repositories;
	using Shift.Repository.Repositories.Implementations;
	using Shift.Repository.Repositories.Interfaces;
	using Shift.Services.Managers.Employee;
	using Shift.Services.Managers.Journals.GJournals;
	using Shift.Services.Managers.Journals.UJournals;
	using Shift.Services.Managers.User;
	using Shift.Services.Providers.Token;
	using Shift.Services.Services.Menu;

	public static class ServicesExtensions
	{
		public static void ConfigureSqlServerDbContext(
			this IServiceCollection services,
			IConfiguration config)
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
			services.AddScoped<IAcademicDegreeRepository, AcademicDegreeRepository>();
			services.AddScoped<IAcademicRankRepository, AcademicRankRepository>();
			services.AddScoped<IJobPositionRepository, JobPositionRepository>();
			services.AddScoped<IDepartmentRepository, DepartmentRepository>();
			services.AddScoped<ISpecialtyRepository, SpecialtyRepository>();
			services.AddScoped<IExamRepository, ExamRepository>();
			services.AddScoped<IWorkPlanRepository, WorkPlanRepository>();
			services.AddScoped<IEducationPhaseRepository, EducationPhaseRepository>();
		}

		public static void ConfigureServices(this IServiceCollection services)
		{
			services.AddTransient<IMenuService, MenuService>();
			services.AddTransient<ITokenProvider, JwtTokenProvider>();
			services.AddTransient<IUserManager, UserManager>();
			services.AddTransient<IUJournalManager, UJournalManager>();
			services.AddTransient<IGJournalManager, GJournalManager>();
			services.AddTransient<IEmployeeManager, EmployeeManager>();
			services.AddScoped<IUJConverter, UJConverterDocx>();
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
					ValidIssuer = Config.Issuer,
					ValidAudience = Config.Audience,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config.Secret)),
				};
			}) ;
		}

		public static void ConfigureCors(this IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy",
					builder => builder.AllowAnyOrigin()
						.AllowAnyMethod()
						.AllowAnyHeader());
			});
		}
	}
}
