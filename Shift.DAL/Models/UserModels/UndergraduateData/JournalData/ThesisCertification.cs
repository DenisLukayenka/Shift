using Shift.DAL.Models.University;
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
		public string PreliminaryResult { get; set; }
		public int Mark { get; set; }

		public DateTime? PreliminaryApproveDate { get; set; }
		public DateTime? ApproveDate { get; set; }

		public string DepartmentHead { get; set; }

		public int? ProtocolId { get; set; }
		public virtual Protocol Protocol { get; set; }

		public virtual UndergraduateJournal UndergraduateJournal { get; set; }
	}
}
