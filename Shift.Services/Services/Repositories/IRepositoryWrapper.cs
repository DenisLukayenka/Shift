using Shift.Services.Services.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Shift.Services.Services.Repositories
{
	public interface IRepositoryWrapper
	{
		IUserRepository Users { get; }
		IUndergraduateRepository Undergraduates { get; }
		IRoleRepository Roles { get; }
		IGraduateRepository Graduates { get; }
		IEmployeeRepository Employees { get; }

		Task SaveAsync();
	}
}
