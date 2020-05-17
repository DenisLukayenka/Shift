using Shift.Infrastructure.Models.ViewModels.Users;
using System.Collections.Generic;

namespace Shift.Services.Managers.Employee
{
	public interface IEmployeeManager
	{
		IEnumerable<GraduateContext> GetGraduates(int userId);
		IEnumerable<UndergraduateContext> GetUndergraduates(int userId);
	}
}
