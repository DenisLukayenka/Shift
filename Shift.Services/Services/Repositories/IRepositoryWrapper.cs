using Shift.Services.Services.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Shift.Services.Services.Repositories
{
	public interface IRepositoryWrapper
	{
		IUserRepository Users { get; }

		Task SaveAsync();
	}
}
