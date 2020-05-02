using Shift.Infrastructure.Models.ViewModels.Journals;

namespace Shift.Services.Managers.Journals.GJournals
{
	public interface IGJournalManager
	{
		GJournal FetchJournal(int userId);
		void SaveJournal(GJournal journal);
	}
}
