﻿using System.Collections.Generic;

namespace Shift.Infrastructure.Models.ViewModels.Journals
{
	using Shift.DAL.Models.UserModels.UndergraduateData.JournalData;

	public class UJournal
	{
		public int Id { get; set; }

		public int? UndergraduateId { get; set; }

		public virtual PreparationInfo PreparationInfo { get; set; }
		public virtual ThesisCertification ThesisCertification { get; set; }

		public virtual ICollection<Report> ReportResults { get; set; } = new List<Report>();
	}
}
