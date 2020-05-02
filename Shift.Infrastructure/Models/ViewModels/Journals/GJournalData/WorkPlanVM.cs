using System;
using System.Collections.Generic;

namespace Shift.Infrastructure.Models.ViewModels.Journals.GJournalData
{
	public class WorkPlanVM
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

		public virtual ICollection<WorkStageVM> WorkStages { get; set; } = new List<WorkStageVM>();
	}
}
