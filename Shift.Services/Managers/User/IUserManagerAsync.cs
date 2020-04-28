using Shift.Infrastructure.Models.ViewModels.Auth;
using System.Threading.Tasks;

namespace Shift.Services.Managers.User
{
	public interface IUserManagerAsync
	{
		/// <summary>
		/// Check the existing of user
		/// </summary>
		/// <param name="user">Login parameters</param>
		/// <returns>User's role</returns>
		Task<string> LoginAsync(LoginViewModel user);
	}
}
