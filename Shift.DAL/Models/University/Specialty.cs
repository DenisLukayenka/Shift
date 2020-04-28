using System.Collections.Generic;

namespace Shift.DAL.Models.University
{
	using Shift.DAL.Models.UserModels.GraduateData;
	using Shift.DAL.Models.UserModels.UndergraduateData;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Specialty
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string Code { get; set; }
		public string Title { get; set; }

		public int? DepartmentId { get; set; }
		public virtual Department Department { get; set; }

		public virtual ICollection<Graduate> Graduates { get; set; } = new List<Graduate>();
		public virtual ICollection<Undergraduate> Undergraduates { get; set; } = new List<Undergraduate>();
	}
}
