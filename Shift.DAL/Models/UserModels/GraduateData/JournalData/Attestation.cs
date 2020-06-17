using System;

namespace Shift.DAL.Models.UserModels.GraduateData.JournalData
{
	using Shift.DAL.Models.University;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Attestation
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

		public int? DepartmentProtocolId { get; set; }
		public virtual Protocol DepartmentProtocol { get; set; }

		public int? CommissionProtocolId { get; set; }
		public virtual Protocol CommissionProtocol { get; set; }

		public string DepartmentResult { get; set; }
		public string CommissionResult { get; set; }

		public int? EducationPhaseId { get; set; }
		public virtual EducationPhase EducationPhase { get; set; }
	}
}
