using System;

namespace Shift.Infrastructure.Models.ViewModels.Journals.GJournalData
{
	using Shift.Infrastructure.Models.ViewModels.University;

	public class AttestationVM
	{
		public int Id { get; set; }

		public string AttestationResult { get; set; }

		public string Adviser { get; set; }
		public DateTime? AdviserApproveDate { get; set; }
		public bool IsAdviserApproved { get; set; } = false;

		public string DepartmentHead { get; set; }
		public DateTime? DepartmentHeadApproveDate { get; set; }
		public bool IsDepartmentHeadApproved { get; set; } = false;

		public string TrainingtHead { get; set; }
		public DateTime? TrainingHeadApproveDate { get; set; }
		public bool IsTrainingHeadApproved { get; set; } = false;

		public virtual ProtocolVM Protocol { get; set; }

		public int? EducationPhaseId { get; set; }
	}
}
