using Shift.Infrastructure.Models.ViewModels.Journals;
using System.Threading.Tasks;

namespace Shift.Services.Managers.Journals.UJournals
{
	public interface IUJournalManager
	{
		UJournal FetchJournal(int userId);
		void SaveJournal(UJournal journal);
	}
}
