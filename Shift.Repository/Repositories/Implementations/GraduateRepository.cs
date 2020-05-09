namespace Shift.Repository.Repositories.Implementations
{
	using Shift.DAL.Models.UserModels.GraduateData;
	using Shift.Repository.Database;
	using Shift.Repository.Repositories.Interfaces;

	public class GraduateRepository: BaseRepository<Graduate>, IGraduateRepository
	{
		public GraduateRepository(CoreContext context)
			: base(context)
		{
		}
	}
}
