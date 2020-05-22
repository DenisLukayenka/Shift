using System.Collections.Generic;

namespace Shift.DAL.Models.UserModels.EmployeeData
{
	using Shift.DAL.Models.University;
	using Shift.DAL.Models.UserModels.GraduateData;
	using Shift.DAL.Models.UserModels.UndergraduateData;
	using Shift.DAL.Models.UserModels.UserData;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Employee
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int EmployeeId { get; set; }

		public int UserId { get; set; }
		public virtual User User { get; set; }

		public int? JobPositionId { get; set; }
		public virtual JobPosition JobPosition { get; set; }

		public int? AcademicDegreeId { get; set; }
		public virtual AcademicDegree AcademicDegree { get; set; }

		public int? AcademicRankId { get; set; }
		public virtual AcademicRank AcademicRank { get; set; }

		public int? DepartmentId { get; set; }
		public virtual Department Department { get; set; }

		public virtual ICollection<Undergraduate> Undergraduates { get; set; } = new List<Undergraduate>();
		public virtual ICollection<Graduate> Graduates { get; set; } = new List<Graduate>();
	}
}
