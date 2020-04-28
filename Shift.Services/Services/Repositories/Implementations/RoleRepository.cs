using Shift.DAL.Models.UserModels.UserData;
using Shift.Services.Contexts;
using Shift.Services.Services.Repositories.Interfaces;

namespace Shift.Services.Services.Repositories.Implementations
{
	public class RoleRepository: BaseRepository<Role>, IRoleRepository
	{
		public RoleRepository(CoreContext context)
			: base(context)
		{
		}
	}
}
