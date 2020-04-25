using System;
using System.Collections.Generic;

namespace Shift.DAL.Models.UserModels.GraduateData.JournalData
{
	public class WorkPlan
	{
		public int WorkPlanId { get; set; }

		public bool IsSubmitted { get; set; } = false;

		public DateTime? SubmitDate { get; set; }

		public string Adviser { get; set; }
		public DateTime? AdviserApproveDate { get; set; }
		public bool IsAdviserApproved { get; set; } = false;

		public string TrainingHead { get; set; }
		public DateTime? TrainingHeadApproveDate { get; set; }
		public bool IsTrainingHeadApproved { get; set; } = false;

		public string FinalCertification { get; set; }
		public string CouncilNumber { get; set; }

		public int? GraduateJournalId { get; set; }
		public virtual GraduateJournal GraduateJournal { get; set; }

		public virtual ICollection<WorkStage> WorkStages { get; set; } = new List<WorkStage>();
	}
}
