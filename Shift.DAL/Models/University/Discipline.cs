using System.Collections.Generic;

namespace Shift.DAL.Models.University
{
	using Shift.DAL.Models.UserModels.UserData;

	public class Discipline
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public string Abbreviation { get; set; }

		public virtual ICollection<ExamInfo> ExamInfo { get; set; } = new List<ExamInfo>();
	}
}
