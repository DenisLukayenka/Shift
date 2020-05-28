using AutoMapper;

using System;

namespace Shift.Services.Managers.Journals.GJournals
{
	using Shift.DAL.Models.UserModels.GraduateData;
	using Shift.DAL.Models.UserModels.GraduateData.JournalData;
	using Shift.DAL.Models.UserModels.UserData;
	using Shift.Infrastructure.Models.ViewModels.Journals;
	using Shift.Repository.Database;
	using Shift.Repository.Repositories;
	using System.Collections.Generic;
	using Microsoft.EntityFrameworkCore;
	using System.Linq;

	public class GJournalManager : IGJournalManager
	{
		private readonly IRepositoryWrapper _repository;
		private readonly IMapper _mapper;
		private readonly CoreContext _context;

		public GJournalManager(IRepositoryWrapper repository, IMapper mapper, CoreContext context)
		{
			this._repository = repository;
			this._mapper = mapper;
			this._context = context;
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
			var journalDal = this._mapper.Map<GraduateJournal>(journal);

			var workPlans = this._mapper.Map<IEnumerable<WorkPlan>>(journal.WorkPlans);
			var educationPhases = this._mapper.Map<IEnumerable<EducationPhase>>(journal.EducationYears);
			var examsData = this._mapper.Map<IEnumerable<ExamInfo>>(journal.ExamsInfo);

			this.SetModifiedOrAddedState(this._context, journalDal.ThesisPlan, journalDal.ThesisPlanId);
			this.SetModifiedOrAddedState(this._context, journalDal.RationalInfo, journalDal.RationalInfoId);

			journalDal.WorkPlans = workPlans.ToList();
			journalDal.EducationYears = educationPhases.ToList();
			journalDal.ExamsData = examsData.ToList();

			this._context.SaveChanges();

			return this._mapper.Map<GJournal>(journalDal);
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
