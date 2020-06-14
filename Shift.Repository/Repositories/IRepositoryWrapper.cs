using Shift.Repository.Repositories.Interfaces;

namespace Shift.Repository.Repositories
{
	public interface IRepositoryWrapper
	{
		IUserRepository Users { get; }
		IUndergraduateRepository Undergraduates { get; }
		IRoleRepository Roles { get; }
		IGraduateRepository Graduates { get; }
		IEmployeeRepository Employees { get; }
		IUJournalRepository UJournals { get; }
		IGJournalRepository GJournals { get; }
		IAcademicDegreeRepository Degrees { get; }
		IAcademicRankRepository Ranks { get; }
		IJobPositionRepository Positions { get; }
		IDepartmentRepository Departments { get; }
		ISpecialtyRepository Specialties { get; }
		IExamRepository Exams { get; }
		IWorkPlanRepository WorkPlans { get; }
		IEducationPhaseRepository EducationPhases { get; }

		void Save();
	}
}
