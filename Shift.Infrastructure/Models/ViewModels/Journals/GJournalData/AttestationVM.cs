using System;

namespace Shift.Infrastructure.Models.ViewModels.Journals.GJournalData
{
	using Shift.Infrastructure.Models.ViewModels.University;

	public class AttestationVM
	{
		public int? Id { get; set; }

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

		public string DepartmentResult { get; set; }
		public string CommissionResult { get; set; }

		public int? DepartmentProtocolId { get; set; }
		public virtual ProtocolVM DepartmentProtocol { get; set; }

		public int? CommissionProtocolId { get; set; }
		public virtual ProtocolVM CommissionProtocol { get; set; }

		public int? EducationPhaseId { get; set; }
	}
}
