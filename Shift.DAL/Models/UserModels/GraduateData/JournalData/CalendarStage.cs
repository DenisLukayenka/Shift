using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shift.DAL.Models.UserModels.GraduateData.JournalData
{
	public class CalendarStage
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string StageName { get; set; }

		public DateTime StartDate { get; set; } = DateTime.Now;
		public DateTime FinishDate { get; set; } = DateTime.Now;

		public string WaitResult { get; set; }

		public string OutcomeResult { get; set; }

		public int? EducationPhaseId { get; set; }
		public virtual EducationPhase EducationPhase { get; set; }
	}
}
