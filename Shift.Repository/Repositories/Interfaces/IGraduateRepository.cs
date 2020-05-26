using Shift.DAL.Models.UserModels.GraduateData;
using System.Linq;

namespace Shift.Repository.Repositories.Interfaces
{
	public interface IGraduateRepository: IRepository<Graduate>
	{
		IQueryable<Graduate> GetGraduatesByEmployee(int employeeId);
	}
}
