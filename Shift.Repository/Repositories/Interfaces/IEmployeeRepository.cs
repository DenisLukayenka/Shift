using Shift.DAL.Models.UserModels.EmployeeData;
using System.Linq;

namespace Shift.Repository.Repositories.Interfaces
{
	public interface IEmployeeRepository: IRepository<Employee>
	{
		IQueryable<Employee> GetAdvisersList();
	}
}
