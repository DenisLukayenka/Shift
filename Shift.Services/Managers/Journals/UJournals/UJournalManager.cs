using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Shift.Services.Managers.Journals.UJournals
{
	using Shift.DAL.Models.UserModels.UndergraduateData;
	using Shift.Infrastructure.Models.ViewModels.Journals;
	using Shift.Repository.Database;
	using Shift.Repository.Repositories;

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
			var journalDal = this._mapper.Map<UndergraduateJournal>(journal);
			this.SetModifiedOrAddedState(this._context, journalDal.PreparationInfo, journalDal.PreparationInfoId);

			foreach (var work in journalDal.PreparationInfo.ResearchWorks)
			{
				this.SetModifiedOrAddedState(this._context, work, work.Id);
			}

			this.SetModifiedOrAddedState(this._context, journalDal.ThesisCertification, journalDal.ThesisCertificationId);

			foreach (var report in journalDal.ReportResults)
			{
				this.SetModifiedOrAddedState(this._context, report, report.Id);
				this.SetModifiedOrAddedState(this._context, report.Protocol, report.ProtocolId);
			}

			this._context.SaveChanges();

			return this._mapper.Map<UJournalVM>(journalDal);
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
