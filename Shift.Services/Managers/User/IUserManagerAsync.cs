using Shift.Infrastructure.Models.ViewModels.Auth;
using System.Threading.Tasks;

namespace Shift.Services.Managers.User
{
	public interface IUserManagerAsync
	{
		/// <summary>
		/// Login user and return user's role if exist
		/// </summary>
		/// <param name="user">Login parameters</param>
		/// <returns>User's role</returns>
		Task<string> LoginAsync(LoginViewModel user);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="undergraduate"></param>
		/// <returns>Alerts with message of erros</returns>
		Task<string> RegisterUndergraduateAsync(UndergraduateViewModel undergraduate);
		Task<string> RegisterGraduateAsync(GraduateViewModel graduate);
		Task<string> RegisterEmployeeAsync(EmployeeViewModel employee);
	}
}
