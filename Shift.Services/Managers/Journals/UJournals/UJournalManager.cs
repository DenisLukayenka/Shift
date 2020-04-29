using Shift.Infrastructure.Models.ViewModels.Journals;
using Shift.Services.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Services.Managers.Journals.UJournals
{
	public class UJournalManager : IUJournalManagerAsync
	{
		private readonly IRepositoryWrapper _repository;

		public UJournalManager(IRepositoryWrapper repository)
		{
			this._repository = repository;
		}

		public Task<UJournal> FetchJournalAsync(int userId)
		{

			throw new NotImplementedException();
		}

		public Task SaveJournalAsync(int journalId, UJournal journal)
		{
			throw new NotImplementedException();
		}
	}
}
