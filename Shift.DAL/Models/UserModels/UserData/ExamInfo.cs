using System;

namespace Shift.DAL.Models.UserModels.UserData
{
	using Shift.DAL.Models.University;
	using Shift.DAL.Models.UserModels.GraduateData;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class ExamInfo
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public int Mark { get; set; }
		public DateTime Date { get; set; } = DateTime.Now;

		public int? DisciplineId { get; set; }
		public virtual Discipline Discipline { get; set; }

		public int? GraduateId { get; set; }
		public virtual Graduate Graduate { get; set; }
	}
}
