using Shift.DAL.Models.University;
using Shift.Repository.Database;
using Shift.Repository.Repositories.Interfaces;

namespace Shift.Repository.Repositories.Implementations
{
	public class SpecialtyRepository: BaseRepository<Specialty>, ISpecialtyRepository
	{
		public SpecialtyRepository(CoreContext context)
			: base(context)
		{
		}
	}
}
