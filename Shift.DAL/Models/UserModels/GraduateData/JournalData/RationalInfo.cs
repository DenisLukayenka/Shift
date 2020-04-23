using System;

namespace Shift.DAL.Models.UserModels.GraduateData.JournalData
{
	using Shift.DAL.Models.University;

	public class RationalInfo
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
		public DateTime? DepartmentHeadRationalApproveDate { get; set; }
		public bool IsDepartmentHeadRationalApproved { get; set; } = false;

		public string TrainingHead { get; set; }
		public DateTime? TrainingHeadRationalApproveDate { get; set; }
		public bool IsTrainingHeadRationalApproved { get; set; } = false;

		public string Adviser { get; set; }
		public DateTime? AdviserRationalApproveDate { get; set; }
		public bool IsAdviserRationalApproved { get; set; } = false;

		public int? ProtocolId { get; set; }
		public virtual Protocol Protocol { get; set; }

		public int? GraduateJournalId { get; set; }
		public virtual GraduateJournal GraduateJournal { get; set; }
	}
}
