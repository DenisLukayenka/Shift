using Shift.DAL.Models.UserModels.EmployeeData;
using Shift.Repository.Database;
using Shift.Repository.Repositories.Interfaces;

namespace Shift.Repository.Repositories.Implementations
{
	public class JobPositionRepository: BaseRepository<JobPosition>, IJobPositionRepository
	{
		public JobPositionRepository(CoreContext context)
			: base(context)
		{
		}
	}
}
