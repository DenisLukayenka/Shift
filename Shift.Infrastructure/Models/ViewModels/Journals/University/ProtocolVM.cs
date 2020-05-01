using System;

namespace Shift.Infrastructure.Models.ViewModels.Journals.University
{
	public class ProtocolVM
	{
		public int ProtocolId { get; set; }
		public DateTime Date { get; set; } = DateTime.Now;
		public int Number { get; set; }
	}
}
