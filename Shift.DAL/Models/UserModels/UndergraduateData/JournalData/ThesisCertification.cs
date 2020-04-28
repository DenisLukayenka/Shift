using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shift.DAL.Models.UserModels.UndergraduateData.JournalData
{
	public class ThesisCertification
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ThesisCertificationId { get; set; }

		public bool IsApproved { get; set; } = false;
		public int Mark { get; set; }

		public DateTime ApproveDate { get; set; }

		public string DepartmentHead { get; set; }

		public int? UndergraduateJournalId { get; set; }
		public virtual UndergraduateJournal UndergraduateJournal { get; set; }
	}
}
