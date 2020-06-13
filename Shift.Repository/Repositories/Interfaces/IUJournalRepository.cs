using Shift.DAL.Models.UserModels.UndergraduateData;

namespace Shift.Repository.Repositories.Interfaces
{
	public interface IUJournalRepository: IRepository<UndergraduateJournal>
	{
		UndergraduateJournal GetByUserId(int userId);
		UndergraduateJournal GetFullByUserId(int userId);
	}
}
