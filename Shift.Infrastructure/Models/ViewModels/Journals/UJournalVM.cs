﻿using System.Collections.Generic;

namespace Shift.Infrastructure.Models.ViewModels.Journals
{
	using Shift.Infrastructure.Models.ViewModels.Journals.UJournalData;

	public class UJournalVM
	{
		public int Id { get; set; }

		public int? UndergraduateId { get; set; }

		public int? PreparationInfoId { get; set; }
		public virtual PreparationInfoVM PreparationInfo { get; set; }

		public int? ThesisCertificationId { get; set; }
		public virtual ThesisCertificationVM ThesisCertification { get; set; }

		public virtual ICollection<ReportVM> ReportResults { get; set; } = new List<ReportVM>();
	}
}
