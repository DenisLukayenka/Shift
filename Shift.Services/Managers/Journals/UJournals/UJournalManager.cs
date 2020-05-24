using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Shift.Services.Managers.Journals.UJournals
{
	using Shift.DAL.Models.UserModels.UndergraduateData;
	using Shift.DAL.Models.UserModels.UndergraduateData.JournalData;
	using Shift.Infrastructure.Models.ViewModels.Journals;
	using Shift.Repository.Database;
	using Shift.Repository.Repositories;
	using System.Collections.Generic;
	using System.Linq;

	public class UJournalManager : IUJournalManager
	{
		private readonly IRepositoryWrapper _repository;
		private readonly IMapper _mapper;
		private readonly CoreContext _context;

		public UJournalManager(IRepositoryWrapper repository, IMapper mapper, CoreContext context)
		{
			this._repository = repository;
			this._mapper = mapper;
			this._context = context;
		}

		public UJournalVM FetchJournal(int userId)
		{
			var dbJournal = this._repository.UJournals.GetByUserId(userId);

			if (dbJournal != null)
			{
				var responseJournal = this._mapper.Map<UJournalVM>(dbJournal);
				return responseJournal;
			}
			return null;
		}

		public UJournalVM SaveJournal(UJournalVM journal)
		{
			var researchWorks = this._mapper.Map<IEnumerable<ResearchWork>>(journal.PreparationInfo.ResearchWorks);

			var journalDal = this._mapper.Map<UndergraduateJournal>(journal);
			journalDal.PreparationInfo.ResearchWorks = this._context.ResearchWorks
				.Where(w => w.PreparationInfoId == journalDal.PreparationInfoId)
				.AsNoTracking()
				.ToList();

			this.SetModifiedOrAddedState(this._context, journalDal.PreparationInfo, journalDal.PreparationInfoId);

			this.UpdateResearchWorksState(researchWorks, journalDal.PreparationInfo.ResearchWorks);
			this.SetModifiedOrAddedState(this._context, journalDal.ThesisCertification, journalDal.ThesisCertificationId);

			foreach (var report in journalDal.ReportResults)
			{
				this.SetModifiedOrAddedState(this._context, report, report.Id);
				this.SetModifiedOrAddedState(this._context, report.Protocol, report.ProtocolId);
			}

			this._context.SaveChanges();

			return this._mapper.Map<UJournalVM>(journalDal);
		}

		private void UpdateResearchWorksState(IEnumerable<ResearchWork> researchWorks, IEnumerable<ResearchWork> researchWorksDb)
		{
			foreach (var work in researchWorksDb)
			{
				if (researchWorks.FirstOrDefault(w => w.Id == work.Id) == null)
				{
					this._context.Entry(work).State = EntityState.Deleted;
				}
			}
			foreach (var work in researchWorks)
			{
				var workDb = researchWorksDb.FirstOrDefault(w => w.Id == work.Id);

				if (workDb == null || workDb.Id == 0)
				{
					this._context.Entry(work).State = EntityState.Added;
				}
				else
				{
					this._context.Entry(work).State = EntityState.Modified;
				}
			}
		}

		private void SetModifiedOrAddedState(CoreContext context, object entity, int? id)
		{
			if (id != null && id.Value != 0)
			{
				context.Entry(entity).State = EntityState.Modified;
			}
			else
			{
				context.Entry(entity).State = EntityState.Added;
			}
		}
	}
}
