using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Shift.Services.Managers.Journals.UJournals
{
	using Shift.DAL.Models.UserModels.UndergraduateData;
	using Shift.DAL.Models.UserModels.UndergraduateData.JournalData;
    using Shift.FileGenerator.Undergraduate;
    using Shift.Infrastructure.Models.ViewModels.Journals;
	using Shift.Repository.Database;
	using Shift.Repository.Repositories;
	using System.Collections.Generic;
	using System.Linq;

	public class UJournalManager : IUJournalManager
	{
		private readonly IRepositoryWrapper _repository;
		private readonly IMapper _mapper;
		private readonly IUJConverter _ujConverter;
		private readonly CoreContext _context;

		public UJournalManager(IRepositoryWrapper repository, IMapper mapper, CoreContext context, IUJConverter ujConverter)
		{
			this._repository = repository;
			this._mapper = mapper;
			this._context = context;
			this._ujConverter = ujConverter;
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
			var journalDal = this._mapper.Map<UndergraduateJournal>(journal);

			var researchWorks = this._mapper.Map<IEnumerable<ResearchWork>>(journal.PreparationInfo.ResearchWorks);
			var reports = this._mapper.Map<IEnumerable<Report>>(journal.ReportResults);

			var researchWorksDb = this._context.ResearchWorks
				.Where(w => w.PreparationInfoId == journalDal.PreparationInfoId)
				.AsNoTracking()
				.ToList();
			var reportResultsDb = this._context.ReportResults
				.Where(r => r.UndergraduateJournalId == journalDal.Id)
				.AsNoTracking()
				.ToList();

			this.SetModifiedOrAddedState(this._context, journalDal.PreparationInfo, journalDal.PreparationInfoId);

			this.UpdateResearchWorksState(researchWorks, researchWorksDb);
			this.UpdateReportResultsState(reports, reportResultsDb, journalDal.Id);

			journalDal.ReportResults = reports.ToList();
			journalDal.PreparationInfo.ResearchWorks = researchWorks.ToList();

			this._context.SaveChanges();

			return this._mapper.Map<UJournalVM>(journalDal);
		}

		public virtual byte[] DownloadJournalDocx(int userId)
		{
			var dbJournal = this._repository.UJournals.GetByUserId(userId);

			if (dbJournal != null)
			{
				var responseJournal = this._mapper.Map<UJournalVM>(dbJournal);
				byte[] journalDocx = this._ujConverter.Convert(responseJournal);

				return journalDocx;
			}

			return null;
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
		private void UpdateReportResultsState(IEnumerable<Report> reports, IEnumerable<Report> reportsDb, int journalId)
		{
			foreach (var report in reportsDb)
			{
				if (reports.FirstOrDefault(w => w.Id == report.Id) == null)
				{
					this._context.Entry(report).State = EntityState.Deleted;
				}
			}
			foreach (var report in reports)
			{
				report.UndergraduateJournalId = journalId;
				var reportDb = reportsDb.FirstOrDefault(w => w.Id == report.Id);

				if (reportDb == null || reportDb.Id == 0)
				{
					this._context.Entry(report).State = EntityState.Added;
				}
				else
				{
					this._context.Entry(report).State = EntityState.Modified;
				}

				this.SetModifiedOrAddedState(this._context, report.Protocol, report.Protocol.ProtocolId);
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
