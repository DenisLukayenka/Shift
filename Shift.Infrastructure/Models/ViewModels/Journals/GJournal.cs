using Shift.Infrastructure.Models.ViewModels.Journals.GJournalData;
using System.Collections.Generic;

namespace Shift.Infrastructure.Models.ViewModels.Journals
{
	public class GJournal
	{
		public int Id { get; set; }

		public int? GraduateId { get; set; }

		public int? RationalInfoId { get; set; }
		public virtual RationalInfoVM RationalInfo { get; set; }

		public int? ThesisPlanId { get; set; }
		public virtual ThesisPlanVM ThesisPlan { get; set; }

		public virtual ICollection<WorkPlanVM> WorkPlans { get; set; } = new List<WorkPlanVM>();
		public virtual ICollection<EducationPhaseVM> EducationYears { get; set; } = new List<EducationPhaseVM>();
		public virtual ICollection<ExamInfoVM> ExamsData { get; set; } = new List<ExamInfoVM>();
	}
}
