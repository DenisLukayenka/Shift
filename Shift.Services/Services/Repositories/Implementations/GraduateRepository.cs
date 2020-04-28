using Shift.DAL.Models.UserModels.GraduateData;
using Shift.Services.Contexts;
using Shift.Services.Services.Repositories.Interfaces;

namespace Shift.Services.Services.Repositories.Implementations
{
	public class GraduateRepository: BaseRepository<Graduate>, IGraduateRepository
	{
		public GraduateRepository(CoreContext context)
			: base(context)
		{
		}
	}
}
