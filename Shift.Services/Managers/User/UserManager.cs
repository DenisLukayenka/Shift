using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Shift.Services.Managers.User
{
	using DAL.Models.UserModels.UserData;

	using Shift.Infrastructure;
	using Shift.Infrastructure.Models;
	using Shift.DAL.Models.UserModels.UndergraduateData;
	using Shift.Infrastructure.Models.ViewModels.Auth;
	using Shift.Services.Services.Repositories;
	using Shift.DAL.Models.UserModels.EmployeeData;
	using Shift.DAL.Models.UserModels.GraduateData;

	public class UserManager : IUserManagerAsync
	{
		private readonly IRepositoryWrapper _repository;

		public UserManager(IRepositoryWrapper repository)
		{
			this._repository = repository;
		}

		public async Task<string> LoginAsync(LoginViewModel user)
		{
			var usersQuery = await this._repository.Users.GetAsync(u =>
				u.LoginData.FirstOrDefault(ld =>
					ld.Login == user.Login && ld.HashPassword == user.Password) != null);
			var dbUsers = usersQuery.ToArray();

			if(dbUsers.Length > 0)
			{
				return dbUsers.FirstOrDefault()?.Role?.Caption;
			}

			return null;
		}

		public async Task<string> RegisterEmployeeAsync(EmployeeViewModel employee)
		{
			var usersQuery = await this._repository.Employees.GetAsync(u => u.User.LoginData.FirstOrDefault(ld => ld.Login == employee.Login) != null);
			var dbEmployees = usersQuery.ToArray();

			if(dbEmployees.Length == 0)
			{
				var entity = new Employee
				{
					User = new User
					{
						FirstName = employee.FirstName,
						LastName = employee.LastName,
						PatronymicName = employee.PatronymicName,
						Email = employee.Email,
						RoleId = await this.FetchRole(RoleNames.Employee),
						LoginData = new List<LoginInfo>()
						{
							new LoginInfo()
							{
								HashPassword = employee.Password,
								Login = employee.Login,
							}
						}
					},
					JobPositionId = employee.JobPositionId,
					AcademicDegreeId = employee.DegreeId,
					AcademicRankId = employee.RankId,
					DepartmentId = employee.DepartmentId,
				};

				await this._repository.Employees.AddAsync(entity);
				await this._repository.SaveAsync();

				return null;
			}

			return Config.LoginExist;
		}

		public async Task<string> RegisterGraduateAsync(GraduateViewModel graduate)
		{
			var usersQuery = await this._repository.Graduates.GetAsync(u => u.User.LoginData.FirstOrDefault(ld => ld.Login == graduate.Login) != null);
			var dbGraduates = usersQuery.ToArray();

			if (dbGraduates.Length == 0)
			{
				var entity = new Graduate
				{
					User = new User
					{
						FirstName = graduate.FirstName,
						LastName = graduate.LastName,
						PatronymicName = graduate.PatronymicName,
						Email = graduate.Email,
						RoleId = await this.FetchRole(RoleNames.Graduate),
						LoginData = new List<LoginInfo>()
						{
							new LoginInfo()
							{
								HashPassword = graduate.Password,
								Login = graduate.Login,
							}
						}
					},
					EducationForm = graduate.EducationForm,
					SpecialtyId = graduate.SpecialtyId,
					ScienceAdviserId = graduate.AdviserId,
					StartEducationDate = graduate.StartEducationDate,
					FinishEducationDate = graduate.FinishEducationDate,
				};

				await this._repository.Graduates.AddAsync(entity);
				await this._repository.SaveAsync();

				return null;
			}

			return Config.LoginExist;
		}

		public async Task<string> RegisterUndergraduateAsync(UndergraduateViewModel undergraduate)
		{
			var usersQuery = await this._repository.Undergraduates.GetAsync(u => u.User.LoginData.FirstOrDefault(ld => ld.Login == undergraduate.Login) != null);
			var dbUndergraduates = usersQuery.ToArray();

			if (dbUndergraduates.Length == 0)
			{
				var entity = new Undergraduate()
				{
					User = new User
					{
						FirstName = undergraduate.FirstName,
						LastName = undergraduate.LastName,
						PatronymicName = undergraduate.PatronymicName,
						Email = undergraduate.Email,
						RoleId = await this.FetchRole(RoleNames.Undergraduate),
						LoginData = new List<LoginInfo>()
						{
							new LoginInfo()
							{
								HashPassword = undergraduate.Password,
								Login = undergraduate.Login
							}
						},
					},
					EducationForm = undergraduate.EducationForm,
					SpecialtyId = undergraduate.SpecialtyId,
					ScienceAdviserId = undergraduate.AdviserId,
					StartEducationDate = undergraduate.StartEducationDate,
					FinishEducationDate = undergraduate.FinishEducationDate,
				};

				await this._repository.Undergraduates.AddAsync(entity);
				await this._repository.SaveAsync();

				return null;
			}
			
			return Config.LoginExist;
		}

		protected async Task<int> FetchRole(string roleCaption)
		{
			var rolesQuery = await this._repository.Roles.GetAsync(r => r.Caption == roleCaption);
			var role = rolesQuery.FirstOrDefault();

			if(role is null)
			{
				var roleEntity = new Role()
				{
					Caption = roleCaption,
				};

				await this._repository.Roles.AddAsync(roleEntity);
				await this._repository.SaveAsync();

				role = roleEntity;
			}

			return role.Id;
		}
	}
}
