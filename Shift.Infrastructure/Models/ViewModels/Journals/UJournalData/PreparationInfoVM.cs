using System;
using System.Collections.Generic;

namespace Shift.Infrastructure.Models.ViewModels.Journals.UJournalData
{
	public class PreparationInfoVM
	{
		public int PreparationInfoId { get; set; }

		public string Topic { get; set; }
		public string Relevance { get; set; }
		public string Objectives { get; set; }
		public string ResearchProcedure { get; set; }

		public string Additions { get; set; }
		public string PreparationAdviser { get; set; }
		public string ResearchAdviser { get; set; }

		public DateTime? PreparationSubmittedDate { get; set; }
		public DateTime? PreparationApprovedDate { get; set; }

		public bool IsPreparationSubmitted { get; set; } = false;
		public bool IsPreparationApproved { get; set; } = false;

		public bool IsReseachSubmitted { get; set; } = false;
		public bool IsResearchApproved { get; set; } = false;

		public DateTime? ReseachSubmittedDate { get; set; }
		public DateTime? ReseachApprovedDate { get; set; }

		public virtual ICollection<ResearchWorkVM> ResearchWorks { get; set; } = new List<ResearchWorkVM>();
	}
}
