using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shift.DAL.Models.UserModels.UndergraduateData
{
	using Shift.DAL.Models.UserModels.UndergraduateData.JournalData;

	public class UndergraduateJournal
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public int? UndergraduateId { get; set; }
		public virtual Undergraduate Undergraduate { get; set; }

		public int? PreparationInfoId { get; set; }
		public virtual PreparationInfo PreparationInfo { get; set; } = new PreparationInfo();

		public int? ThesisCertificationId { get; set; }
		public virtual ThesisCertification ThesisCertification { get; set; } = new ThesisCertification();

		public virtual ICollection<Report> ReportResults { get; set; } = new List<Report>();
	}
}
