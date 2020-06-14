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
			var dbJournal = this._repository.GJournals.GetByIdTracking(journal.Id);

			dbJournal.RationalInfo = this._mapper.Map<RationalInfo>(journal.RationalInfo);
			dbJournal.ThesisPlan = this._mapper.Map<ThesisPlan>(journal.ThesisPlan);
			dbJournal.WorkPlans = this._mapper.Map<ICollection<WorkPlan>>(journal.WorkPlans);
			dbJournal.EducationYears = this._mapper.Map<ICollection<EducationPhase>>(journal.EducationYears);
			dbJournal.ExamsData = this._mapper.Map<ICollection<ExamInfo>>(journal.ExamsData);

			this._context.SaveChanges();

			return this._mapper.Map<GJournal>(dbJournal);
		}
	}
}
