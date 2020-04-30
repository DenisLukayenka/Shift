using Shift.Infrastructure.Models.ViewModels.Auth;

namespace Shift.Services.Providers.Token
{
	public interface ITokenProvider
	{
		string GenerateToken(string login, string role);
	}
}
