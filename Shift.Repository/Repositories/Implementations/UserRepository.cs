using Microsoft.EntityFrameworkCore;

using System;
using System.Linq;
using System.Linq.Expressions;

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
	}
}

