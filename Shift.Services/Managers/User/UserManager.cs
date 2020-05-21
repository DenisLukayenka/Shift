using AutoMapper;

using System.Linq;

namespace Shift.Services.Managers.User
{
	using Shift.DAL.Models.UserModels.UndergraduateData;
	using Shift.Infrastructure.Models.ViewModels.Auth;
	using Shift.DAL.Models.UserModels.EmployeeData;
	using Shift.DAL.Models.UserModels.GraduateData;
	using Shift.Repository.Repositories;
	using Shift.Infrastructure.Models.SharedData;
	using Shift.DAL.Models.UserModels.UserData;
    using Shift.Infrastructure.Models.ViewModels.Users;

    public class UserManager : IUserManager
	{
		private readonly IRepositoryWrapper _repository;
		private readonly IMapper _mapper;

		public UserManager(IRepositoryWrapper repository, IMapper mapper)
		{
			this._repository = repository;
			this._mapper = mapper;
		}

		public AuthResponse Login(LoginVM user)
		{
			var dbUser = this._repository.Users.Get(u =>
				u.LoginData.FirstOrDefault(ld =>
					ld.Login == user.Login && 
					ld.HashPassword == user.Password) != null)
			.FirstOrDefault();

			var context = new AuthResponse();

			if(dbUser != null)
			{
				var loginInfo = dbUser.LoginData.FirstOrDefault();

				context.User = this._mapper.Map<UserContext>(dbUser);
				return context;
			}

			context.Alert = Config.InvalidAuth;

			return context;
		}

		public AuthResponse RegisterEmployee(EmployeeViewModel employee)
		{
			var dbEmployee = this._repository.Employees
				.Get(u => u.User.LoginData.FirstOrDefault(ld => ld.Login == employee.Login.Login) != null)
				.FirstOrDefault();
			var context = new AuthResponse();

			if(dbEmployee == null)
			{
				var entity = this._mapper.Map<Employee>(employee);
				entity.User.Role = this.GetOrAddRole(RoleNames.Employee);

				this._repository.Employees.Add(entity);
				this._repository.Save();

				context.User = this._mapper.Map<UserContext>(entity.User);

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
				var entity = this._mapper.Map<Graduate>(graduate);
				entity.User.Role = this.GetOrAddRole(RoleNames.Graduate);

				this._repository.Graduates.Add(entity);
				this._repository.Save();

				context.User = this._mapper.Map<UserContext>(entity.User);

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
				var entity = this._mapper.Map<Undergraduate>(undergraduate);
				entity.User.Role = this.GetOrAddRole(RoleNames.Undergraduate);

				this._repository.Undergraduates.Add(entity);
				this._repository.Save();

				context.User = this._mapper.Map<UserContext>(entity.User);

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

		protected Role GetOrAddRole(string roleCaption)
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

			return role;
		}
	}
}
