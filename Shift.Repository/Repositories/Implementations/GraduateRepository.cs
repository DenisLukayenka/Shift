namespace Shift.Repository.Repositories.Implementations
{
	using Microsoft.EntityFrameworkCore;
	using Shift.DAL.Models.UserModels.GraduateData;
	using Shift.Repository.Database;
	using Shift.Repository.Repositories.Interfaces;
	using System.Linq;

	public class GraduateRepository: BaseRepository<Graduate>, IGraduateRepository
	{
		public GraduateRepository(CoreContext context)
			: base(context)
		{
		}

		public IQueryable<Graduate> GetGraduatesByEmployee(int employeeId)
		{
			return this.AppContext.Graduates
				.Where(u => u.ScienceAdviserId == employeeId)
				.Include(u => u.GraduateJournals)
				.Include(u => u.User)
					.ThenInclude(u => u.LoginData)
				.Include(u => u.User)
					.ThenInclude(u => u.Role);
		}
	}
}
