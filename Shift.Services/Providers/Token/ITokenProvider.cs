using Microsoft.IdentityModel.Tokens;

namespace Shift.Services.Providers.Token
{
	public interface ITokenProvider
	{
		string GenerateToken(string login, string role);
	}
}
