using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shift.DAL.Models.University
{
	public class Protocol
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ProtocolId { get; set; }
		public DateTime? Date { get; set; }

		public string Number { get; set; }
	}
}
