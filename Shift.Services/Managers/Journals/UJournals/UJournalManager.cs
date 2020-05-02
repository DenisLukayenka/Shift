using AutoMapper;
using Shift.Infrastructure.Models.ViewModels.Journals;
using Shift.Services.Services.Repositories;
using System;
using System.Linq;

namespace Shift.Services.Managers.Journals.UJournals
{
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
			var dbJournal = this._repository.UJournals
				.Get(journal => journal.Undergraduate.UserId == userId)
				.FirstOrDefault();

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
