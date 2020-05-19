using Shift.DAL.Models.UserModels.EmployeeData;
using Shift.Repository.Database;
using Shift.Repository.Repositories.Interfaces;

namespace Shift.Repository.Repositories.Implementations
{
	public class AcademicRankRepository: BaseRepository<AcademicRank>, IAcademicRankRepository
	{
		public AcademicRankRepository(CoreContext context)
			: base(context)
		{
		}
	}
}
