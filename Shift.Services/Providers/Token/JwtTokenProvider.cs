using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shift.Services.Providers.Token
{
	public class JwtTokenProvider : ITokenProvider
	{
		public static string Issuer = "http://localhost:4200";
		public static string Audience = "http://localhost:50280";

		public string GenerateToken(string login, string role)
		{
			var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("qwertgdhgy@1gfdhhhfd11"));
			var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, login),
				new Claim(ClaimTypes.Role, role),
			};

			var tokeOptions = new JwtSecurityToken(
					JwtTokenProvider.Issuer,
					JwtTokenProvider.Audience,
					claims,
					null,
					DateTime.Now.AddMinutes(4),
					signinCredentials
				);

			var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

			return tokenString;
		}
	}
}
