using Shift.Repository.Repositories.Interfaces;

namespace Shift.Repository.Repositories
{
	public interface IRepositoryWrapper
	{
		IUserRepository Users { get; }
		IUndergraduateRepository Undergraduates { get; }
		IRoleRepository Roles { get; }
		IGraduateRepository Graduates { get; }
		IEmployeeRepository Employees { get; }
		IUJournalRepository UJournals { get; }
		IGJournalRepository GJournals { get; }


		void Save();
	}
}
