using System.Collections.Generic;

namespace Shift.DAL.Models.UserModels.UndergraduateData
{
	using Shift.DAL.Models.University;
	using Shift.DAL.Models.UserModels.EmployeeData;
	using Shift.DAL.Models.UserModels.UndergraduateData.JournalData;

	public class UndergraduateJournal
	{
		public int Id { get; set; }

		public int? UndergraduateId { get; set; }
		public virtual Undergraduate Undergraduate { get; set; }

		public int? ScienceAdviserId { get; set; }
		public virtual Employee ScienceAdviser { get; set; }

		public int? UniversitySettingsId { get; set; }
		public virtual UniversitySettings Settings { get; set; }

		public virtual PreparationInfo PreparationInfo { get; set; }
		public virtual ThesisCertification ThesisCertification { get; set; }

		public virtual ICollection<ReportResult> ReportResults { get; set; } = new List<ReportResult>();
	}
}
