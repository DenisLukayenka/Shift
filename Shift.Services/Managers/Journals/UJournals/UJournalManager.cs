using Shift.Infrastructure.Models.ViewModels.Journals;
using Shift.Services.Services.Repositories;
using System;
using System.Linq;

namespace Shift.Services.Managers.Journals.UJournals
{
	public class UJournalManager : IUJournalManager
	{
		private readonly IRepositoryWrapper _repository;

		public UJournalManager(IRepositoryWrapper repository)
		{
			this._repository = repository;
		}

		public UJournal FetchJournal(int userId)
		{
			var dbJournal = this._repository.Undergraduates
				.Get(user => user.UserId == userId)
				.FirstOrDefault()?
				.Journals
				.FirstOrDefault();

			if(dbJournal != null)
			{
				var responseJournal = new UJournal
				{
					Id = dbJournal.Id,
					PreparationInfo = dbJournal.PreparationInfo,
					ReportResults = dbJournal.ReportResults,
					ThesisCertification = dbJournal.ThesisCertification,
					UndergraduateId = dbJournal.UndergraduateId,
				};

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
