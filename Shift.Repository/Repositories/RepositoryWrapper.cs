using Shift.Repository.Database;
using Shift.Repository.Repositories.Interfaces;

namespace Shift.Repository.Repositories
{
	public class RepositoryWrapper : IRepositoryWrapper
	{
		private readonly CoreContext _dbContext;
		private readonly IUserRepository _userRepository;
		private readonly IUndergraduateRepository _undergraduateRepository;
		private readonly IRoleRepository _roleRepository;
		private readonly IEmployeeRepository _employeeRepository;
		private readonly IGraduateRepository _graduateRepository;
		private readonly IUJournalRepository _uJournalRepository;
		private readonly IGJournalRepository _gJournalRepository;

		public RepositoryWrapper(
			CoreContext repositoryContext,
			IUserRepository userRepository,
			IUndergraduateRepository undergraduateRepository,
			IRoleRepository roleRepository,
			IEmployeeRepository employeeRepository,
			IGraduateRepository graduateRepository,
			IUJournalRepository uJournalRepository,
			IGJournalRepository gJournalRepository)
		{
			this._dbContext = repositoryContext;

			this._userRepository = userRepository;
			this._undergraduateRepository = undergraduateRepository;
			this._roleRepository = roleRepository;
			this._employeeRepository = employeeRepository;
			this._graduateRepository = graduateRepository;
			this._uJournalRepository = uJournalRepository;
			this._gJournalRepository = gJournalRepository;
		}

		public virtual IUserRepository Users => this._userRepository;

		public virtual IUndergraduateRepository Undergraduates => this._undergraduateRepository;

		public virtual IRoleRepository Roles => this._roleRepository;

		public virtual IEmployeeRepository Employees => this._employeeRepository;

		public virtual IGraduateRepository Graduates => this._graduateRepository;

		public virtual IUJournalRepository UJournals => this._uJournalRepository;

		public virtual IGJournalRepository GJournals => this._gJournalRepository;

		public virtual void Save()
		{
			this._dbContext.SaveChangesAsync();
		}
	}
}
