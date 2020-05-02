using System;
using System.Collections.Generic;

namespace Shift.Infrastructure.Models.ViewModels.Journals.GJournalData
{
	public class EducationPhaseVM
	{
		public int Id { get; set; }

		public string TripsInternships { get; set; }
		public string SubWorks { get; set; }

		public string Publications { get; set; }
		public string ScienceParticipations { get; set; }
		public string SubResearchResults { get; set; }

		public int? JournalId { get; set; }

		public string Adviser { get; set; }
		public DateTime? AdviserApproveDate { get; set; }
		public bool IsAdviserApproved { get; set; } = false;

		public DateTime? SubmitDate { get; set; }
		public bool IsSubmitted { get; set; } = false;

		public virtual ICollection<CalendarStageVM> CalendarStages { get; set; } = new List<CalendarStageVM>();
		public virtual ICollection<ScienceActivityVM> ScienceActivities { get; set; } = new List<ScienceActivityVM>();
		public virtual ICollection<AttestationVM> Attestations { get; set; } = new List<AttestationVM>();
	}
}
