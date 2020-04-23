using System;

namespace Shift.DAL.Models.UserModels.GraduateData.JournalData
{
	public class ThesisPlan
	{
		public int ThesisPlanId { get; set; }

		public string ThesisPlanInfo { get; set; }
		public string Adviser { get; set; }

		public DateTime? AdviserThesisPlanApproveDate { get; set; }
		public DateTime? ThesisPlanSubmitDate { get; set; }

		public bool IsThesisPlanSubmitted { get; set; } = false;
		public bool IsThesisPlanApproved { get; set; } = false;
	}
}
