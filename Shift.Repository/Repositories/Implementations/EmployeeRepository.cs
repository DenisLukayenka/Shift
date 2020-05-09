namespace Shift.Repository.Repositories.Implementations
{
	using Shift.DAL.Models.UserModels.EmployeeData;
	using Shift.Repository.Database;
	using Shift.Repository.Repositories.Interfaces;

	public class EmployeeRepository: BaseRepository<Employee>, IEmployeeRepository
	{
		public EmployeeRepository(CoreContext context)
			: base(context)
		{
		}
	}
}
