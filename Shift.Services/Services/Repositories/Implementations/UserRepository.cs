using Microsoft.EntityFrameworkCore;
using Shift.DAL.Models.UserModels.UserData;
using Shift.Services.Contexts;
using Shift.Services.Services.Repositories.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shift.Services.Services.Repositories.Implementations
{
	public class UserRepository: BaseRepository<User>, IUserRepository
	{
		public UserRepository(CoreContext context)
			: base(context)
		{ 
		}

		public override async Task<IQueryable<User>> GetAsync(Expression<Func<User, bool>> expression)
		{
			return this.AppContext.Set<User>().Where(expression).Include(u => u.Role).AsNoTracking();
		}
	}
}

