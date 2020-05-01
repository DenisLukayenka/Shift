using Shift.Infrastructure.Models.ViewModels.Journals.University;
using System;

namespace Shift.Infrastructure.Models.ViewModels.Journals.UJournalData
{
	public class ReportVM
	{
		public int Id { get; set; }

		public DateTime Date { get; set; }
		public string Result { get; set; }
		public string DepartmentHead { get; set; }
		public virtual ProtocolVM Protocol { get; set; }
	}
}
