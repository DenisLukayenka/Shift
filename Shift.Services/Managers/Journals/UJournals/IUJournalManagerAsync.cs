using Shift.Infrastructure.Models.ViewModels.Journals;
using System.Threading.Tasks;

namespace Shift.Services.Managers.Journals.UJournals
{
	public interface IUJournalManagerAsync
	{
		Task<UJournal> FetchJournalAsync(int userId);
		Task SaveJournalAsync(int journalId, UJournal journal);
	}
}
