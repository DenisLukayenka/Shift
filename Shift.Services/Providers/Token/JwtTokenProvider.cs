using Microsoft.IdentityModel.Tokens;
using Shift.Infrastructure.Models.SharedData;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shift.Services.Providers.Token
{
	public class JwtTokenProvider : ITokenProvider
	{
		public string GenerateToken(string login, string role)
		{
			var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config.Secret));
			var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, login),
				new Claim(ClaimTypes.Role, role),
			};

			var tokenOptions = new JwtSecurityToken(
					Config.Issuer,
					Config.Audience,
					claims,
					DateTime.Now,
					DateTime.Now.AddHours(4),
					signinCredentials
				);

			var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

			return tokenString;
		}
	}
}
