using Shift.DAL.Models.UserModels.UndergraduateData;
using Shift.Services.Contexts;
using Shift.Services.Services.Repositories.Interfaces;

namespace Shift.Services.Services.Repositories.Implementations
{
	public class UJournalRepository: BaseRepository<UndergraduateJournal>, IUJournalRepository
	{
		public UJournalRepository(CoreContext context)
			: base(context)
		{
		}
	}
}
