using Shift.Infrastructure.Models.ViewModels.University;
using System;

namespace Shift.Infrastructure.Models.ViewModels.Journals.UJournalData
{
	public class ThesisCertificationVM
	{
		public int ThesisCertificationId { get; set; }

		public bool IsApproved { get; set; } = false;
		public string PreliminaryResult { get; set; }
		public int? Mark { get; set; }

		public DateTime? PreliminaryApproveDate { get; set; }
		public DateTime? ApproveDate { get; set; }

		public string DepartmentHead { get; set; }

		public int? ProtocolId { get; set; }
		public virtual ProtocolVM Protocol { get; set; }
	}
}
