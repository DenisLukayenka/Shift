using System;
using System.Collections.Generic;

namespace Shift.DAL.Models.UserModels.GraduateData.JournalData
{
	public class WorkPlan
	{
		public int WorkPlanId { get; set; }

		public bool IsPlanSubmitted { get; set; } = false;

		public DateTime? PlanSubmitDate { get; set; }

		public string Adviser { get; set; }
		public DateTime? AdviserPlanApproveDate { get; set; }
		public bool IsAdviserPlanApproved { get; set; } = false;

		public string TrainingHead { get; set; }
		public DateTime? TrainingHeadPlanApproveDate { get; set; }
		public bool IsTrainingHeadPlanApproved { get; set; } = false;

		public string FinalCertification { get; set; }
		public string CouncilNumber { get; set; }

		public int? GraduateJournalId { get; set; }
		public virtual GraduateJournal GraduateJournal { get; set; }

		public virtual ICollection<WorkStage> WorkStages { get; set; } = new List<WorkStage>();
	}
}
