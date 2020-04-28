using Shift.DAL.Models.UserModels.UndergraduateData;
using Shift.Services.Contexts;
using Shift.Services.Services.Repositories.Interfaces;

namespace Shift.Services.Services.Repositories.Implementations
{
	public class UndergraduateRepository: BaseRepository<Undergraduate>, IUndergraduateRepository
	{
		public UndergraduateRepository(CoreContext context)
			: base(context)
		{
		}
	}
}
