using Shift.DAL.Models.UserModels.UndergraduateData;
using System.Linq;

namespace Shift.Repository.Repositories.Interfaces
{
	public interface IUndergraduateRepository: IRepository<Undergraduate>
	{
		IQueryable<Undergraduate> GetUndergraduatesByEmployee(int employeeId);
	}
}
