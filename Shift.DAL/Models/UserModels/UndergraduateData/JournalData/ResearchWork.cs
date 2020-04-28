using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shift.DAL.Models.UserModels.UndergraduateData.JournalData
{
	public class ResearchWork
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string JobType { get; set; }

		public string PresentationType { get; set; }

		public DateTime? StartDate { get; set; }
		public DateTime? FinishDate { get; set; }

		public int? PreparationInfoId { get; set; }
		public virtual PreparationInfo PreparationInfo { get; set; }
	}
}
