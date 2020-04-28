using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shift.DAL.Models.UserModels.GraduateData.JournalData
{
	public class EducationPhase
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string TripsInternships { get; set; }
		public string SubWorks { get; set; }

		public string Publications { get; set; }
		public string ScienceParticipations { get; set; }
		public string SubResearchResults { get; set; }

		public int? JournalId { get; set; }
		public GraduateJournal Journal { get; set; }

		public string Adviser { get; set; }
		public DateTime? AdviserApproveDate { get; set; }
		public bool IsAdviserApproved { get; set; } = false;

		public DateTime? SubmitDate { get; set; }
		public bool IsSubmitted { get; set; } = false;

		public virtual ICollection<CalendarStage> CalendarStages { get; set; } = new List<CalendarStage>();
		public virtual ICollection<ScienceActivity> ScienceActivities { get; set; } = new List<ScienceActivity>();
		public virtual ICollection<Attestation> Attestations { get; set; } = new List<Attestation>();
	}
}
