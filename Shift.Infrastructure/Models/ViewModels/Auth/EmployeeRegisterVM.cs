using Shift.Infrastructure.Models.ViewModels.Data;

namespace Shift.Infrastructure.Models.ViewModels.Auth
{
	public class EmployeeRegisterVM
	{
		public UserRegisterVM User { get; set; }

		public AcademicDegreeVM AcademicDegree { get; set; }
		public AcademicRankVM AcademicRank { get; set; }
		public JobPositionVM JobPosition { get; set; }
		public DepartmentVM Department { get; set; }
	}
}
