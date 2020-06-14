using Shift.DAL.Models.UserModels.GraduateData;

namespace Shift.Repository.Repositories.Interfaces
{
	public interface IGJournalRepository: IRepository<GraduateJournal>
	{
		GraduateJournal GetByUserId(int userId);
		GraduateJournal GetByIdTracking(int graduateJournalId);
	}
}
