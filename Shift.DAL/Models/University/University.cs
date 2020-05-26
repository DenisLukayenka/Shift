using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shift.DAL.Models.University
{
	public class University
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Abbreviation { get; set; }

		public string ViceRector { get; set; }

		public string ScientificTrainingHead { get; set; }

		public ICollection<Faculty> Faculties { get; set; } = new List<Faculty>();
	}
}
