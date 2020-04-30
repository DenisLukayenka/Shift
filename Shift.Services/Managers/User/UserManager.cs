using System.Linq;
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

	public class UserManager : IUserManager
	{
		private readonly IRepositoryWrapper _repository;

		public UserManager(IRepositoryWrapper repository)
		{
			this._repository = repository;
		}

		public AuthResponse Login(LoginViewModel user)
		{
			var dbUser = this._repository.Users.Get(u =>
				u.LoginData.FirstOrDefault(ld =>
					ld.Login == user.Login && ld.HashPassword == user.Password) != null).FirstOrDefault();

			var context = new AuthResponse();

			if(dbUser != null)
			{
				var loginInfo = dbUser.LoginData.FirstOrDefault();

				context.User = new UserContext
				{
					UserId = dbUser.Id,
					FirstName = dbUser.FirstName,
					LastName = dbUser.LastName,
					Login = loginInfo?.Login,
					Role = dbUser.Role?.Caption,
				};

				return context;
			}

			context.Alert = Config.InvalidAuth;

			return context;
		}

		public AuthResponse RegisterEmployee(EmployeeViewModel employee)
		{
			var dbEmployee = this._repository.Employees
				.Get(u => u.User.LoginData.FirstOrDefault(ld => ld.Login == employee.Login) != null)
				.FirstOrDefault();
			var context = new AuthResponse();

			if(dbEmployee == null)
			{
				var entity = new Employee
				{
					User = new User
					{
						FirstName = employee.FirstName,
						LastName = employee.LastName,
						PatronymicName = employee.PatronymicName,
						Email = employee.Email,
						RoleId = this.GetOrAddRole(RoleNames.Employee),
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

				this._repository.Employees.Add(entity);
				this._repository.Save();

				context.User = new UserContext
				{
					UserId = entity.User.Id,
					FirstName = entity.User.FirstName,
					LastName = entity.User.LastName,
					Login = entity.User.LoginData.FirstOrDefault().Login,
					Role = entity.User.Role?.Caption,
				};

				return context;
			}

			context.Alert = Config.LoginExist;
			return context;
		}

		public AuthResponse RegisterGraduate(GraduateViewModel graduate)
		{
			var dbGradute = this._repository.Graduates
				.Get(u => u.User.LoginData.FirstOrDefault(ld => ld.Login == graduate.Login) != null)
				.FirstOrDefault();

			var context = new AuthResponse();

			if (dbGradute == null)
			{
				var entity = new Graduate
				{
					User = new User
					{
						FirstName = graduate.FirstName,
						LastName = graduate.LastName,
						PatronymicName = graduate.PatronymicName,
						Email = graduate.Email,
						RoleId = this.GetOrAddRole(RoleNames.Graduate),
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

				this._repository.Graduates.Add(entity);
				this._repository.Save();

				context.User = new UserContext
				{
					UserId = entity.User.Id,
					FirstName = entity.User.FirstName,
					LastName = entity.User.LastName,
					Login = entity.User.LoginData.FirstOrDefault().Login,
					Role = entity.User.Role?.Caption,
				};

				return context;
			}

			context.Alert = Config.LoginExist;
			return context;
		}

		public AuthResponse RegisterUndergraduate(UndergraduateViewModel undergraduate)
		{
			var dbUndergraduate = this._repository.Undergraduates
				.Get(u => u.User.LoginData.FirstOrDefault(ld => ld.Login == undergraduate.Login) != null)
				.FirstOrDefault();
			var context = new AuthResponse();

			if (dbUndergraduate == null)
			{
				var entity = new Undergraduate()
				{
					User = new User
					{
						FirstName = undergraduate.FirstName,
						LastName = undergraduate.LastName,
						PatronymicName = undergraduate.PatronymicName,
						Email = undergraduate.Email,
						RoleId = this.GetOrAddRole(RoleNames.Undergraduate),
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

				this._repository.Undergraduates.Add(entity);
				this._repository.Save();

				context.User = new UserContext
				{
					UserId = entity.User.Id,
					FirstName = entity.User.FirstName,
					LastName = entity.User.LastName,
					Login = entity.User.LoginData.FirstOrDefault().Login,
					Role = entity.User.Role?.Caption,
				};

				return context;
			}

			context.Alert = Config.LoginExist;
			return context;
		}

		public string FetchUserRole(int userId)
		{
			var dbUser = this._repository.Users.Get(u => u.Id == userId).FirstOrDefault();

			if(dbUser != null)
			{
				return dbUser.Role.Caption;
			}

			return null;
		}

		protected int GetOrAddRole(string roleCaption)
		{
			var role = this._repository.Roles.Get(r => r.Caption == roleCaption).FirstOrDefault();

			if(role is null)
			{
				var roleEntity = new Role()
				{
					Caption = roleCaption,
				};

				this._repository.Roles.Add(roleEntity);
				this._repository.Save();

				role = roleEntity;
			}

			return role.Id;
		}
	}
}
