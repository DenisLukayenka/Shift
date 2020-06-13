using Microsoft.EntityFrameworkCore;

using System.Linq;

namespace Shift.Repository.Repositories.Implementations
{

	using Shift.DAL.Models.UserModels.UndergraduateData;
	using Shift.Repository.Database;
	using Shift.Repository.Repositories.Interfaces;

	public class UJournalRepository: BaseRepository<UndergraduateJournal>, IUJournalRepository
	{
		public UJournalRepository(CoreContext context)
			: base(context)
		{
		}

		public virtual UndergraduateJournal GetByUserId(int userId)
		{
			return this.AppContext.UndergraduateJournal
				.Include(j => j.PreparationInfo).ThenInclude(pi => pi.ResearchWorks)
				.Include(j => j.ThesisCertification).ThenInclude(t => t.Protocol)
				.Include(j => j.ReportResults).ThenInclude(j => j.Protocol)
				.Include(j => j.Undergraduate)
				.AsNoTracking()

				.FirstOrDefault(journal => journal.Undergraduate.UserId == userId);
		}
	}
}
