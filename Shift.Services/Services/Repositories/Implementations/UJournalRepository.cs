using Microsoft.EntityFrameworkCore;
using Shift.DAL.Models.UserModels.UndergraduateData;
using Shift.Services.Contexts;
using Shift.Services.Services.Repositories.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Shift.Services.Services.Repositories.Implementations
{
	public class UJournalRepository: BaseRepository<UndergraduateJournal>, IUJournalRepository
	{
		public UJournalRepository(CoreContext context)
			: base(context)
		{
		}

		public override IQueryable<UndergraduateJournal> Get(Expression<Func<UndergraduateJournal, bool>> expression)
		{
			return this.AppContext.Set<UndergraduateJournal>()
				.Where(expression)
				.Include(j => j.PreparationInfo)
					.ThenInclude(pi => pi.ResearchWorks)
				.Include(j => j.Settings)
				.Include(j => j.ThesisCertification)
				.Include(j => j.ReportResults)
					.ThenInclude(j => j.Protocol)
				.AsNoTracking();
		}
	}
}
