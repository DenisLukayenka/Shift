using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Shift.Infrastructure.Models.ViewModels.Auth;

namespace Shift.Web.Controllers
{
	[Route("api/auth")]
	[ApiController]
	public class AuthController: ControllerBase
	{
		[HttpPost]
		[Route("login")]
		public IActionResult Login([FromBody] LoginViewModel user)
		{
			if(user is null)
			{
				return BadRequest("Invalid client request!");
			}

			if(user.Login == "jogn" && user.Password == "111")
			{
				var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("qwertgdhgy@1gfdhhhfd11"));
				var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, user.Login),
					new Claim(ClaimTypes.Role, "Manager"),
				};

				var tokeOptions = new JwtSecurityToken(
					"http://localhost:4200",
					"http://localhost:50280",
					claims,
					null,
					DateTime.Now.AddMinutes(4),
					signinCredentials
				);

				var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
				return Ok(new { Token = tokenString });
			}
			else
			{
				return Unauthorized();
			}
		}

	}
}
