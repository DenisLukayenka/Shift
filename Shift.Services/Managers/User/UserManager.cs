using Shift.Infrastructure.Models.ViewModels.Auth;
using Shift.Services.Providers.Token;
using Shift.Services.Services.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace Shift.Services.Managers.User
{
	public class UserManager : IUserManagerAsync
	{
		private readonly IRepositoryWrapper _repository;
		private readonly ITokenProvider _tokenProvider;

		public UserManager(IRepositoryWrapper repository, ITokenProvider tokenProvider)
		{
			this._repository = repository;
			this._tokenProvider = tokenProvider;
		}

		public async Task<string> LoginAsync(LoginViewModel user)
		{
			var usersQuery = await this._repository.Users.GetAsync(u =>
				u.LoginData.FirstOrDefault(ld =>
					ld.Login == user.Login && ld.HashPassword == user.Password) != null);
			var dbUsers = usersQuery.ToArray();

			if(dbUsers.Length > 0)
			{
				var role = dbUsers.First().Role.Caption;

				return this._tokenProvider.GenerateToken(user.Login, role);
			}

			return null;
		}
	}
}
