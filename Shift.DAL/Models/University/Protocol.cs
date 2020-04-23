using System;

namespace Shift.DAL.Models.University
{
	public class Protocol
	{
		public int ProtocolId { get; set; }
		public DateTime Date { get; set; } = DateTime.Now;

		public int Number { get; set; }
	}
}
