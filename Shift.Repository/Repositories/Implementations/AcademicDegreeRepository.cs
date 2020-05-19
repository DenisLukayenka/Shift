using Shift.DAL.Models.UserModels.EmployeeData;
using Shift.Repository.Database;
using Shift.Repository.Repositories.Interfaces;

namespace Shift.Repository.Repositories.Implementations
{
	public class AcademicDegreeRepository: BaseRepository<AcademicDegree>, IAcademicDegreeRepository
	{
		public AcademicDegreeRepository(CoreContext context)
			: base(context)
		{
		}
	}
}
