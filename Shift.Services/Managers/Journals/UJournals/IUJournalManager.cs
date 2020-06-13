using Shift.Infrastructure.Models.ViewModels.Journals;
using System.IO;

namespace Shift.Services.Managers.Journals.UJournals
{
	public interface IUJournalManager
	{
		UJournalVM FetchJournal(int userId);
		UJournalVM SaveJournal(UJournalVM journal);
		byte[] DownloadJournalDocx(int userId);
	}
}
