using Shift.Services.Contexts;
using Shift.Services.Services.Repositories.Implementations;
using Shift.Services.Services.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Shift.Services.Services.Repositories
{
	public class RepositoryWrapper : IRepositoryWrapper
	{
		private readonly CoreContext _dbContext;
		private IUserRepository _userRepository;
		private IUndergraduateRepository _undergraduateRepository;
		private IRoleRepository _roleRepository;
		private IEmployeeRepository _employeeRepository;
		private IGraduateRepository _graduateRepository;
		private IUJournalRepository _uJournalRepository;
		private IGJournalRepository _gJournalRepository;

		public RepositoryWrapper(CoreContext repositoryContext)
		{
			this._dbContext = repositoryContext;
		}

		public IUserRepository Users 
		{ 
			get 
			{
				if(this._userRepository is null)
				{
					this._userRepository = new UserRepository(this._dbContext);
				}

				return this._userRepository;
			}
		}

		public IUndergraduateRepository Undergraduates
		{
			get
			{
				if(this._undergraduateRepository is null)
				{
					this._undergraduateRepository = new UndergraduateRepository(this._dbContext);
				}

				return this._undergraduateRepository;
			}
		}

		public IRoleRepository Roles
		{
			get
			{
				if (this._roleRepository is null)
				{
					this._roleRepository = new RoleRepository(this._dbContext);
				}

				return this._roleRepository;
			}
		}

		public IEmployeeRepository Employees
		{
			get
			{
				if (this._employeeRepository is null)
				{
					this._employeeRepository = new EmployeeRepository(this._dbContext);
				}

				return this._employeeRepository;
			}
		}

		public IGraduateRepository Graduates
		{
			get
			{
				if (this._graduateRepository is null)
				{
					this._graduateRepository = new GraduateRepository(this._dbContext);
				}

				return this._graduateRepository;
			}
		}

		public IUJournalRepository UJournals
		{
			get
			{
				if (this._uJournalRepository is null)
				{
					this._uJournalRepository = new UJournalRepository(this._dbContext);
				}

				return this._uJournalRepository;
			}
		}

		public IGJournalRepository GJournals
		{
			get
			{
				if (this._gJournalRepository is null)
				{
					this._gJournalRepository = new GJournalRepository(this._dbContext);
				}

				return this._gJournalRepository;
			}
		}

		public async Task SaveAsync()
		{
			await this._dbContext.SaveChangesAsync();
		}
	}
}
