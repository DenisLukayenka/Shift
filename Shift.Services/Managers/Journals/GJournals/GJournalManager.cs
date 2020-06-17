using AutoMapper;

using System.Collections.Generic;

namespace Shift.Services.Managers.Journals.GJournals
{
	using Shift.DAL.Models.UserModels.GraduateData.JournalData;
	using Shift.DAL.Models.UserModels.UserData;
    using Shift.FileGenerator.GJournal;
    using Shift.Infrastructure.Models.ViewModels.Journals;
	using Shift.Repository.Database;
	using Shift.Repository.Repositories;

	public class GJournalManager : IGJournalManager
	{
		private readonly IRepositoryWrapper _repository;
		private readonly IMapper _mapper;
		private readonly CoreContext _context;
		private readonly IGJConverter _gjConverter;

		public GJournalManager(IRepositoryWrapper repository, IMapper mapper, CoreContext context, IGJConverter gjConverter)
		{
			this._repository = repository;
			this._mapper = mapper;
			this._context = context;
			this._gjConverter = gjConverter;
		}

		public GJournal FetchJournal(int userId)
		{
			var dbJournal = this._repository.GJournals.GetByUserId(userId);

			if (dbJournal != null)
			{
				var responseJournal = this._mapper.Map<GJournal>(dbJournal);
				return responseJournal;
			}
			return null;
		}

		public GJournal SaveJournal(GJournal journal)
		{
			var dbJournal = this._repository.GJournals.GetByIdTracking(journal.Id);

			dbJournal.RationalInfo = this._mapper.Map<RationalInfo>(journal.RationalInfo);
			dbJournal.ThesisPlan = this._mapper.Map<ThesisPlan>(journal.ThesisPlan);
			dbJournal.WorkPlans = this._mapper.Map<ICollection<WorkPlan>>(journal.WorkPlans);
			dbJournal.EducationYears = this._mapper.Map<ICollection<EducationPhase>>(journal.EducationYears);
			dbJournal.ExamsData = this._mapper.Map<ICollection<ExamInfo>>(journal.ExamsData);

			this._repository.Exams.DeleteExcept(dbJournal.ExamsData, journal.Id);
			this._repository.WorkPlans.DeleteExcept(dbJournal.WorkPlans, journal.Id);
			this._repository.EducationPhases.UpdateEducationPhases(dbJournal.EducationYears);

			this._context.SaveChanges();

			return this._mapper.Map<GJournal>(dbJournal);
		}

		public virtual byte[] DownloadJournalDocx(int userId)
		{
			var dbJournal = this._repository.GJournals.GetFullByUserId(userId);

			if (dbJournal != null)
			{
				byte[] journalDocx = this._gjConverter.Convert(dbJournal);

				return journalDocx;
			}

			return null;
		}
	}
}
