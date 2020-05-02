using Microsoft.EntityFrameworkCore;
using Shift.DAL.Models.UserModels.GraduateData;
using Shift.Services.Contexts;
using Shift.Services.Services.Repositories.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Shift.Services.Services.Repositories.Implementations
{
	public class GJournalRepository: BaseRepository<GraduateJournal>, IGJournalRepository
	{
		public GJournalRepository(CoreContext context)
			: base(context)
		{
		}

		public override IQueryable<GraduateJournal> Get(Expression<Func<GraduateJournal, bool>> expression)
		{
			return this.AppContext.Set<GraduateJournal>()
				.Where(expression)
				.Include(j => j.RationalInfo).ThenInclude(pi => pi.Protocol)
				.Include(j => j.ThesisPlan)

				.Include(j => j.WorkPlans).ThenInclude(p => p.WorkStages)

				.Include(j => j.EducationYears).ThenInclude(j => j.CalendarStages)
				.Include(j => j.EducationYears).ThenInclude(j => j.ScienceActivities)
				.Include(j => j.EducationYears).ThenInclude(j => j.Attestations).ThenInclude(a => a.Protocol)
				.Include(j => j.Graduate)
				.AsNoTracking();
		}
	}
}
