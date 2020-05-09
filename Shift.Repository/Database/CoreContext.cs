using Microsoft.EntityFrameworkCore;

namespace Shift.Repository.Database
{
	using Shift.DAL.Models.University;
	using Shift.DAL.Models.UserModels.EmployeeData;
	using Shift.DAL.Models.UserModels.GraduateData;
	using Shift.DAL.Models.UserModels.GraduateData.JournalData;
	using Shift.DAL.Models.UserModels.UndergraduateData;
	using Shift.DAL.Models.UserModels.UndergraduateData.JournalData;
	using Shift.DAL.Models.UserModels.UserData;

	public class CoreContext : DbContext
	{
		#region DbSets

		#region University

		public DbSet<Faculty> Faculties { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<Specialty> Specialties { get; set; }
		public DbSet<UniversitySettings> UniversitySettings { get; set; }
		public DbSet<Discipline> Disciplines { get; set; }

		#endregion

		#region Users

		#region Users

		public DbSet<User> Users { get; set; }
		public DbSet<LoginInfo> LoginInfo { get; set; }
		public DbSet<ExamInfo> ExamInfo { get; set; }
		public DbSet<Role> Roles { get; set; }

		#endregion

		#region Employees

		public DbSet<Employee> Employees { get; set; }
		public DbSet<AcademicDegree> AcademicDegrees { get; set; }
		public DbSet<AcademicRank> AcademicRanks { get; set; }
		public DbSet<JobPosition> JobPositions { get; set; }

		#endregion

		#region Graduate

		public DbSet<Graduate> Graduates { get; set; }
		public DbSet<GraduateJournal> GraduateJournals { get; set; }
		public DbSet<RationalInfo> RationalInfo { get; set; }
		public DbSet<ThesisPlan> ThesisPlans { get; set; }
		public DbSet<WorkPlan> WorkPlans { get; set; }
		public DbSet<WorkStage> WorkStages { get; set; }
		public DbSet<EducationPhase> EducationPhases { get; set; }
		public DbSet<CalendarStage> CalendarStages { get; set; }
		public DbSet<ScienceActivity> ScienceActivities { get; set; }
		public DbSet<Attestation> Attestations { get; set; }

		#endregion

		#region Undergraduate

		public DbSet<Undergraduate> Undergraduates { get; set; }
		public DbSet<UndergraduateJournal> UndergraduateJournal { get; set; }
		public DbSet<PreparationInfo> PreparationInfo { get; set; }
		public DbSet<Report> ReportResults { get; set; }
		public DbSet<ResearchWork> ResearchWorks { get; set; }
		public DbSet<ThesisCertification> ThesisCertifications { get; set; }

		#endregion

		#endregion

		#endregion

		public CoreContext(DbContextOptions options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
		}
	}
}
