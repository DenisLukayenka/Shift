using Shift.Infrastructure.Models.ViewModels.Auth;

namespace Shift.Services.Managers.User
{
	public interface IUserManager
	{
		AuthResponse Login(LoginVM user);
		AuthResponse RegisterUndergraduate(UndergraduateRegisterVM undergraduate);
		AuthResponse RegisterGraduate(GraduateRegisterVM graduate);
		AuthResponse RegisterEmployee(EmployeeRegisterVM employee);

		string FetchUserRole(int userId);
	}
}
