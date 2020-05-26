using Shift.DAL.Models.UserModels.UserData;

namespace Shift.Repository.Repositories.Interfaces
{
	public interface IUserRepository: IRepository<User>
	{
		User FindByLoginPassword(string login, string password);
		User FindById(int userId);
	}
}
