using Microsoft.EntityFrameworkCore;

using System.Linq;

namespace Shift.Repository.Repositories.Implementations
{
	using Shift.DAL.Models.UserModels.GraduateData;
	using Shift.Repository.Database;
	using Shift.Repository.Repositories.Interfaces;

	public class GJournalRepository: BaseRepository<GraduateJournal>, IGJournalRepository
	{
		public GJournalRepository(CoreContext context)
			: base(context)
		{
		}

		public virtual GraduateJournal GetByUserId(int userId)
		{
			return this.AppContext.GraduateJournals
				.Include(j => j.RationalInfo).ThenInclude(pi => pi.Protocol)
				.Include(j => j.ThesisPlan)
				.Include(j => j.WorkPlans).ThenInclude(p => p.WorkStages)
				.Include(j => j.EducationYears).ThenInclude(j => j.CalendarStages)
				.Include(j => j.EducationYears).ThenInclude(j => j.ScienceActivities)
				.Include(j => j.EducationYears).ThenInclude(j => j.Attestations).ThenInclude(a => a.Protocol)
				.Include(j => j.Graduate)
				.Include(j => j.ExamsData).ThenInclude(e => e.Discipline)
				.AsNoTracking()

				.FirstOrDefault(journal => journal.Graduate.UserId == userId);
		}

		public virtual GraduateJournal GetByIdTracking(int graduateJournalId)
        {
			return this.AppContext.GraduateJournals.FirstOrDefault(j => j.Id == graduateJournalId);
        }
	}
}
