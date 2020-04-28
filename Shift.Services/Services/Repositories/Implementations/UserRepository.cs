using Shift.DAL.Models.UserModels.UserData;
using Shift.Services.Contexts;
using Shift.Services.Services.Repositories.Interfaces;

namespace Shift.Services.Services.Repositories.Implementations
{
	public class UserRepository: BaseRepository<User>, IUserRepository
	{
		public UserRepository(CoreContext context)
			: base(context)
		{
		}
	}
}
