using System;
using System.Linq;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

namespace Shift.Repository.Repositories.Implementations
{
	using Shift.DAL.Models.UserModels.UserData;
	using Shift.Repository.Database;
	using Shift.Repository.Repositories.Interfaces;

	public class UserRepository: BaseRepository<User>, IUserRepository
	{
		public UserRepository(CoreContext context)
			: base(context)
		{ 
		}

		public override IQueryable<User> Get(Expression<Func<User, bool>> expression)
		{
			return this.AppContext.Set<User>().Where(expression).Include(u => u.Role).Include(u => u.LoginData).AsNoTracking();
		}

		public User FindByLoginPassword(string login, string password)
		{
			return this.AppContext.Users
				.Include(u => u.LoginData)
				.Include(u => u.Undergraduate)
				.Include(u => u.Graduate)
				.Include(u => u.Employee)
				.Include(u => u.Role)
				.FirstOrDefault(u => u.LoginData.FirstOrDefault(ld => ld.Login == login && ld.HashPassword == password) != null);
		}
	}
}

