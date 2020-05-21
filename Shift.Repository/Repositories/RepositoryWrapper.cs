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
		private readonly IAcademicDegreeRepository _degreeRepository;
		private readonly IAcademicRankRepository _rankRepository;
		private readonly IJobPositionRepository _positionRepository;
		private readonly IDepartmentRepository _departmentRepository;

		public RepositoryWrapper(
			CoreContext repositoryContext,
			IUserRepository userRepository,
			IUndergraduateRepository undergraduateRepository,
			IRoleRepository roleRepository,
			IEmployeeRepository employeeRepository,
			IGraduateRepository graduateRepository,
			IUJournalRepository uJournalRepository,
			IGJournalRepository gJournalRepository,
			IAcademicDegreeRepository degreeRepository,
			IAcademicRankRepository rankRepository,
			IJobPositionRepository positionRepository,
			IDepartmentRepository departmentRepository
			)
		{
			this._dbContext = repositoryContext;

			this._userRepository = userRepository;
			this._undergraduateRepository = undergraduateRepository;
			this._roleRepository = roleRepository;
			this._employeeRepository = employeeRepository;
			this._graduateRepository = graduateRepository;
			this._uJournalRepository = uJournalRepository;
			this._gJournalRepository = gJournalRepository;
			this._degreeRepository = degreeRepository;
			this._rankRepository = rankRepository;
			this._positionRepository = positionRepository;
			this._departmentRepository = departmentRepository;
		}

		public virtual IUserRepository Users => this._userRepository;
		public virtual IUndergraduateRepository Undergraduates => this._undergraduateRepository;
		public virtual IRoleRepository Roles => this._roleRepository;
		public virtual IEmployeeRepository Employees => this._employeeRepository;
		public virtual IGraduateRepository Graduates => this._graduateRepository;
		public virtual IUJournalRepository UJournals => this._uJournalRepository;
		public virtual IGJournalRepository GJournals => this._gJournalRepository;

		public virtual IAcademicDegreeRepository Degrees => this._degreeRepository;
		public virtual IAcademicRankRepository Ranks => this._rankRepository;
		public virtual IJobPositionRepository Positions => this._positionRepository;
		public virtual IDepartmentRepository Departments => this._departmentRepository;

		public virtual void Save()
		{
			this._dbContext.SaveChangesAsync();
		}
	}
}
