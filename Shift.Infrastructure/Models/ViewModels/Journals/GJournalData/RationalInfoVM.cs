using System;

namespace Shift.Infrastructure.Models.ViewModels.Journals.GJournalData
{
	using Shift.Infrastructure.Models.ViewModels.University;

	public class RationalInfoVM
	{
		public int RationalInfoId { get; set; }

		public string StudyPurpose { get; set; }
		public string StudyObject { get; set; }
		public string StudySubject { get; set; }
		public string Justification { get; set; }

		public string ThesisPublications { get; set; }
		public string ReseachParticipation { get; set; }

		public string DissertationTopic { get; set; }

		public string DepartmentHead { get; set; }
		public DateTime? DepartmentHeadApproveDate { get; set; }
		public bool IsDepartmentHeadApproved { get; set; } = false;

		public string TrainingHead { get; set; }
		public DateTime? TrainingHeadApproveDate { get; set; }
		public bool IsTrainingHeadApproved { get; set; } = false;

		public string Adviser { get; set; }
		public DateTime? AdviserApproveDate { get; set; }
		public bool IsAdviserApproved { get; set; } = false;

		public virtual ProtocolVM Protocol { get; set; }

		public int? GraduateJournalId { get; set; }
	}
}
