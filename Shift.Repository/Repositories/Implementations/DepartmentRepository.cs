using Shift.DAL.Models.University;
using Shift.Repository.Database;
using Shift.Repository.Repositories.Interfaces;

namespace Shift.Repository.Repositories.Implementations
{
	public class DepartmentRepository: BaseRepository<Department>, IDepartmentRepository
	{
		public DepartmentRepository(CoreContext context)
			: base(context)
		{
		}
	}
}
