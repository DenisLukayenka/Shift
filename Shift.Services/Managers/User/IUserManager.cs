using Shift.Infrastructure.Models.ViewModels.Auth;
using Shift.Infrastructure.Models.ViewModels.Users;

namespace Shift.Services.Managers.User
{
	public interface IUserManager
	{
		AuthResponse Login(LoginVM user);
		AuthResponse RegisterUndergraduate(UndergraduateRegisterVM undergraduate);
		AuthResponse RegisterGraduate(GraduateRegisterVM graduate);
		AuthResponse RegisterEmployee(EmployeeRegisterVM employee);

		UserContext GetUserContext(int userId);

		string FetchUserRole(int userId);
	}
}
