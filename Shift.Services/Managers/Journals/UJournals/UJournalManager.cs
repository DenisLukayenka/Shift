using AutoMapper;

using System;

namespace Shift.Services.Managers.Journals.UJournals
{
	using Shift.Infrastructure.Models.ViewModels.Journals;
	using Shift.Repository.Repositories;

	public class UJournalManager : IUJournalManager
	{
		private readonly IRepositoryWrapper _repository;
		private readonly IMapper _mapper;

		public UJournalManager(IRepositoryWrapper repository, IMapper mapper)
		{
			this._repository = repository;
			this._mapper = mapper;
		}

		public UJournal FetchJournal(int userId)
		{
			var dbJournal = this._repository.UJournals.GetByUserId(userId);

			if(dbJournal != null)
			{
				var responseJournal = this._mapper.Map<UJournal>(dbJournal);
				return responseJournal;
			}
			return null;
		}

		public void SaveJournal(UJournal journal)
		{
			throw new NotImplementedException();
		}
	}
}
