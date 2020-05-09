namespace Shift.Repository.Repositories.Implementations
{
	using Shift.DAL.Models.UserModels.UndergraduateData;
	using Shift.Repository.Database;
	using Shift.Repository.Repositories.Interfaces;

	public class UndergraduateRepository: BaseRepository<Undergraduate>, IUndergraduateRepository
	{
		public UndergraduateRepository(CoreContext context)
			: base(context)
		{
		}
	}
}
