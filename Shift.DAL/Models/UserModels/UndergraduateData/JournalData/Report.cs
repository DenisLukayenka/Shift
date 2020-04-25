using System;

namespace Shift.DAL.Models.UserModels.UndergraduateData.JournalData
{
	using Shift.DAL.Models.University;

	public class Report
	{
		public int Id { get; set; }

		public DateTime Date { get; set; }
		public string Result { get; set; }
		public string DepartmentHead { get; set; }

		public int? UndergraduateJournalId { get; set; }
		public virtual UndergraduateJournal UndergraduateJournal { get; set; }

		public int? ProtocolId { get; set; }
		public virtual Protocol Protocol { get; set; }
	}
}
