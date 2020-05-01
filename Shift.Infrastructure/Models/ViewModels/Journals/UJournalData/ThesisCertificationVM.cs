using System;

namespace Shift.Infrastructure.Models.ViewModels.Journals.UJournalData
{
	public class ThesisCertificationVM
	{
		public int ThesisCertificationId { get; set; }

		public bool IsApproved { get; set; } = false;
		public int Mark { get; set; }

		public DateTime ApproveDate { get; set; }

		public string DepartmentHead { get; set; }
	}
}
