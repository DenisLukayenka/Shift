using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shift.DAL.Models.UserModels.GraduateData.JournalData
{
	public class WorkStage
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string JobInfo { get; set; }

		public DateTime StartDate { get; set; }
		public DateTime FinishDate { get; set; }

		public DateTime SubmitDate { get; set; }
		public DateTime ApproveDate { get; set; }

		public bool IsSubmitted { get; set; } = false;
		public bool IsApproved { get; set; } = false;

		public string Note { get; set; }

		public int? WorkPlanId { get; set; }
		public virtual WorkPlan WorkPlan { get; set; }
	}
}
