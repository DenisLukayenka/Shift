using Shift.Infrastructure.Models.ViewModels.Journals;
using System.Threading.Tasks;

namespace Shift.Services.Managers.Journals.UJournals
{
	public interface IUJournalManager
	{
		UJournalVM FetchJournal(int userId);
		UJournalVM SaveJournal(UJournalVM journal);
	}
}
