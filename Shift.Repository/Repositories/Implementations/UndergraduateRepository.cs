namespace Shift.Repository.Repositories.Implementations
{
	using Microsoft.EntityFrameworkCore;
	using Shift.DAL.Models.UserModels.UndergraduateData;
	using Shift.Repository.Database;
	using Shift.Repository.Repositories.Interfaces;
	using System.Linq;

	public class UndergraduateRepository: BaseRepository<Undergraduate>, IUndergraduateRepository
	{
		public UndergraduateRepository(CoreContext context)
			: base(context)
		{
		}

		public IQueryable<Undergraduate> GetUndergraduatesByEmployee(int employeeId)
		{
			return this.AppContext.Undergraduates
				.Where(u => u.ScienceAdviserId == employeeId)
				.Include(u => u.Journals)
				.Include(u => u.User)
					.ThenInclude(u => u.LoginData)
				.Include(u => u.User)
					.ThenInclude(u => u.Role);
		}
	}
}
