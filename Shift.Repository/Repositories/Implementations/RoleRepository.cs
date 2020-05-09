namespace Shift.Repository.Repositories.Implementations
{
	using Shift.DAL.Models.UserModels.UserData;
	using Shift.Repository.Database;
	using Shift.Repository.Repositories.Interfaces;

	public class RoleRepository: BaseRepository<Role>, IRoleRepository
	{
		public RoleRepository(CoreContext context)
			: base(context)
		{
		}
	}
}
