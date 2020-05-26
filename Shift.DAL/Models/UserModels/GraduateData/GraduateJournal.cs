using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shift.DAL.Models.UserModels.GraduateData
{
	using Shift.DAL.Models.UserModels.GraduateData.JournalData;
	using Shift.DAL.Models.UserModels.UserData;

	public class GraduateJournal
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public int? GraduateId { get; set; }
		public virtual Graduate Graduate { get; set; }

		public int? RationalInfoId { get; set; }
		public virtual RationalInfo RationalInfo { get; set; } = new RationalInfo();

		public int? ThesisPlanId { get; set; }
		public virtual ThesisPlan ThesisPlan { get; set; } = new ThesisPlan();

		public virtual ICollection<WorkPlan> WorkPlans { get; set; } = new List<WorkPlan>();
		public virtual ICollection<EducationPhase> EducationYears { get; set; } = new List<EducationPhase>();
		public virtual ICollection<ExamInfo> ExamsData { get; set; } = new List<ExamInfo>();
	}
}
