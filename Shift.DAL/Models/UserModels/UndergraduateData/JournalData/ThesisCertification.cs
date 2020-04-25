using System;

namespace Shift.DAL.Models.UserModels.UndergraduateData.JournalData
{
	public class ThesisCertification
	{
		public int ThesisCertificationId { get; set; }

		public bool IsApproved { get; set; } = false;
		public int Mark { get; set; }

		public DateTime ApproveDate { get; set; }

		public string DepartmentHead { get; set; }

		public int? UndergraduateJournalId { get; set; }
		public virtual UndergraduateJournal UndergraduateJournal { get; set; }
	}
}
