using System.Linq;

namespace Shift.Repository.Repositories.Implementations
{
	using Microsoft.EntityFrameworkCore;
	using Shift.DAL.Models.UserModels.EmployeeData;
	using Shift.Repository.Database;
	using Shift.Repository.Repositories.Interfaces;

	public class EmployeeRepository: BaseRepository<Employee>, IEmployeeRepository
	{
		public EmployeeRepository(CoreContext context)
			: base(context)
		{
		}

		public virtual IQueryable<Employee> GetAdvisersList()
		{
			return this.AppContext.Employees.Include(e => e.User);
		}
	}
}
