using System.Collections.Generic;

namespace Shift.DAL.Models.UserModels.UndergraduateData
{
	using Shift.DAL.Models.University;
	using Shift.DAL.Models.UserModels.UndergraduateData.JournalData;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class UndergraduateJournal
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public int? UndergraduateId { get; set; }
		public virtual Undergraduate Undergraduate { get; set; }

		public int? UniversitySettingsId { get; set; }
		public virtual UniversitySettings Settings { get; set; }

		public virtual PreparationInfo PreparationInfo { get; set; }
		public virtual ThesisCertification ThesisCertification { get; set; }

		public virtual ICollection<Report> ReportResults { get; set; } = new List<Report>();
	}
}
