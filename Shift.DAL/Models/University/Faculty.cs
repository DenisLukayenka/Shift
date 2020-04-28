using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shift.DAL.Models.University
{
	public class Faculty
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Abbreviation { get; set; }
		public string Dean { get; set; }

		public ICollection<Department> Departments { get; set; } = new List<Department>();
	}
}
