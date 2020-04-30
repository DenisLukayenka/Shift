using Shift.Infrastructure.Models.ViewModels.Auth;

namespace Shift.Services.Managers.User
{
	public interface IUserManager
	{
		AuthResponse Login(LoginViewModel user);
		AuthResponse RegisterUndergraduate(UndergraduateViewModel undergraduate);
		AuthResponse RegisterGraduate(GraduateViewModel graduate);
		AuthResponse RegisterEmployee(EmployeeViewModel employee);

		string FetchUserRole(int userId);
	}
}
