using Shift.DAL.Models.UserModels.EmployeeData;
using Shift.Services.Contexts;
using Shift.Services.Services.Repositories.Interfaces;

namespace Shift.Services.Services.Repositories.Implementations
{
	public class EmployeeRepository: BaseRepository<Employee>, IEmployeeRepository
	{
		public EmployeeRepository(CoreContext context)
			: base(context)
		{
		}
	}
}
