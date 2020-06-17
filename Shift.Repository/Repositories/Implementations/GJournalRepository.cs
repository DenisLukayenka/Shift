using Microsoft.EntityFrameworkCore;

using System.Linq;

namespace Shift.Repository.Repositories.Implementations
{
	using Shift.DAL.Models.UserModels.GraduateData;
    using Shift.DAL.Models.UserModels.GraduateData.JournalData;
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
				.Include(j => j.EducationYears).ThenInclude(j => j.Attestations).ThenInclude(a => a.CommissionProtocol)
				.Include(j => j.EducationYears).ThenInclude(j => j.Attestations).ThenInclude(a => a.DepartmentProtocol)
				.Include(j => j.Graduate)
				.Include(j => j.ExamsData).ThenInclude(e => e.Discipline)
				.AsNoTracking()

				.FirstOrDefault(journal => journal.Graduate.UserId == userId);
		}

		public virtual GraduateJournal GetByIdTracking(int graduateJournalId)
        {
			return this.AppContext.GraduateJournals.FirstOrDefault(j => j.Id == graduateJournalId);
        }

		public virtual GraduateJournal GetFullByUserId(int userId)
		{
			return this.AppContext.GraduateJournals
				.Include(j => j.Graduate)
				.Include(j => j.Graduate).ThenInclude(u => u.ScienceAdviser).ThenInclude(a => a.User)
				.Include(j => j.Graduate).ThenInclude(u => u.User)
				.Include(j => j.Graduate)
					.ThenInclude(u => u.Specialty)
					.ThenInclude(s => s.Department)
					.ThenInclude(d => d.Faculty)
					.ThenInclude(f => f.University)
				.Include(j => j.RationalInfo)
				.Include(j => j.RationalInfo)
					.ThenInclude(r => r.Protocol)
				.Include(j => j.ThesisPlan)
				.Include(j => j.WorkPlans)
					.ThenInclude(w => w.WorkStages)
				.Include(j => j.ExamsData)
					.ThenInclude(e => e.Discipline)
				.Include(j => j.EducationYears)
				.Include(j => j.EducationYears)
					.ThenInclude(e => e.ScienceActivities)
				.Include(j => j.EducationYears)
					.ThenInclude(e => e.Attestations)
					.ThenInclude(a => a.DepartmentProtocol)
				.Include(j => j.EducationYears)
					.ThenInclude(e => e.Attestations)
					.ThenInclude(a => a.CommissionProtocol)
				.Include(j => j.EducationYears)
					.ThenInclude(e => e.CalendarStages)
				.AsNoTracking()

				.FirstOrDefault(journal => journal.Graduate.UserId == userId);
		}
	}
}
