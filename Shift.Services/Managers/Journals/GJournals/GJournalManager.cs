using AutoMapper;

using System;

namespace Shift.Services.Managers.Journals.GJournals
{
	using Shift.Infrastructure.Models.ViewModels.Journals;
	using Shift.Repository.Repositories;

	public class GJournalManager : IGJournalManager
	{
		private readonly IRepositoryWrapper _repository;
		private readonly IMapper _mapper;

		public GJournalManager(IRepositoryWrapper repository, IMapper mapper)
		{
			this._repository = repository;
			this._mapper = mapper;
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

		public void SaveJournal(GJournal journal)
		{
			throw new NotImplementedException();
		}
	}
}
