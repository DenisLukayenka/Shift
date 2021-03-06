﻿using AutoMapper;

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
	using DAL.Models.UserModels.GraduateData.JournalData;
	using DAL.Models.University;
    using Shift.DAL.Models.UserModels.UndergraduateData.JournalData;

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
			var dbUser = this._repository.Users.FindByLoginPassword(user.Login, user.Password);
			var context = new AuthResponse();

			if(dbUser != null)
			{
				context.User = this._mapper.Map<UserContext>(dbUser);
				return context;
			}

			context.Alert = Config.InvalidAuth;
			return context;
		}

		public AuthResponse RegisterEmployee(EmployeeRegisterVM employee)
		{
			var dbUser = this._repository.Users.FindByLoginPassword(employee.User.Login.Login, employee.User.Login.Password);
			var context = new AuthResponse();

			if(dbUser == null)
			{
				var entity = this._mapper.Map<Employee>(employee);
				entity.User.RoleId = this.GetOrAddRole(RoleNames.Employee);

				this._repository.Employees.Add(entity);
				this._repository.Save();

				context.User = this._mapper.Map<UserContext>(entity.User);
				context.User.Role = RoleNames.Employee;
				context.User.SpecifiedUserId = entity.EmployeeId;

				return context;
			}

			context.Alert = Config.LoginExist;
			return context;
		}

		public AuthResponse RegisterGraduate(GraduateRegisterVM graduate)
		{
			var dbUser = this._repository.Users.FindByLoginPassword(graduate.User.Login.Login, graduate.User.Login.Password);
			var context = new AuthResponse();

			if (dbUser == null)
			{
				var entity = this._mapper.Map<Graduate>(graduate);
				var journal = new GraduateJournal();
				var educationPhase = new EducationPhase();
				var attestaion = new Attestation();
				attestaion.DepartmentProtocol = new Protocol();
				attestaion.CommissionProtocol = new Protocol();
				educationPhase.Attestations.Add(attestaion);

				journal.EducationYears.Add(educationPhase);
				journal.RationalInfo.Protocol = new Protocol();
				journal.WorkPlans.Add(new WorkPlan());

				entity.GraduateJournals.Add(journal);
				entity.User.RoleId = this.GetOrAddRole(RoleNames.Graduate);

				this._repository.Graduates.Add(entity);
				this._repository.Save();

				context.User = this._mapper.Map<UserContext>(entity.User);
				context.User.Role = RoleNames.Graduate;
				context.User.SpecifiedUserId = entity.GraduateId;

				return context;
			}

			context.Alert = Config.LoginExist;
			return context;
		}

		public AuthResponse RegisterUndergraduate(UndergraduateRegisterVM undergraduate)
		{
			var dbUser = this._repository.Users.FindByLoginPassword(undergraduate.User.Login.Login, undergraduate.User.Login.Password);
			var context = new AuthResponse();

			if (dbUser == null)
			{
				var entity = this._mapper.Map<Undergraduate>(undergraduate);

				var thesisData = new ThesisCertification()
				{
					Protocol = new Protocol()
				};
				var journal = new UndergraduateJournal()
				{
					ThesisCertification = thesisData
				};

				entity.Journals.Add(journal);
				entity.User.RoleId = this.GetOrAddRole(RoleNames.Undergraduate);

				this._repository.Undergraduates.Add(entity);
				this._repository.Save();

				context.User = this._mapper.Map<UserContext>(entity.User);
				context.User.Role = RoleNames.Undergraduate;
				context.User.SpecifiedUserId = entity.UndergraduateId;

				return context;
			}

			context.Alert = Config.LoginExist;
			return context;
		}

		public UserContext GetUserContext(int userId)
		{
			var dbUser = this._repository.Users.FindById(userId);
			if(dbUser != null)
			{
				var context = this._mapper.Map<UserContext>(dbUser);

				return context;
			}

			return null;
		}

		public string FetchUserRole(int userId)
		{
			var dbUser = this._repository.Users.Get(u => u.UserId == userId).FirstOrDefault();

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
