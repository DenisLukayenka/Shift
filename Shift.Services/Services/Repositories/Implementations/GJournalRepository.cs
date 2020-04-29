using Shift.DAL.Models.UserModels.GraduateData;
using Shift.Services.Contexts;
using Shift.Services.Services.Repositories.Interfaces;

namespace Shift.Services.Services.Repositories.Implementations
{
	public class GJournalRepository: BaseRepository<GraduateJournal>, IGJournalRepository
	{
		public GJournalRepository(CoreContext context)
			: base(context)
		{
		}
	}
}
