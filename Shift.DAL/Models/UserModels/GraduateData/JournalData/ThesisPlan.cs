using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shift.DAL.Models.UserModels.GraduateData.JournalData
{
	public class ThesisPlan
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ThesisPlanId { get; set; }

		public string Info { get; set; }
		public string Adviser { get; set; }

		public DateTime? AdviserApproveDate { get; set; }
		public DateTime? SubmitDate { get; set; }

		public bool IsSubmitted { get; set; } = false;
		public bool IsApproved { get; set; } = false;

		public int? GraduateJournalId { get; set; }
		public GraduateJournal GraduateJournal { get; set; }
	}
}
