using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Shift.Infrastructure;
using Shift.Infrastructure.Models.ViewModels.Auth;
using Shift.Services.Managers.User;

namespace Shift.Web.Controllers
{
	[Route("api/auth")]
	[ApiController]
	public class AuthController: ControllerBase
	{
		private readonly IUserManagerAsync _userManager;

		public AuthController(IUserManagerAsync userManager)
		{
			this._userManager = userManager;
		}

		[HttpPost]
		[Route("login")]
		public async Task<IActionResult> Login([FromBody] LoginViewModel user)
		{
			if(user is null)
			{
				return BadRequest("Invalid client request!");
			}

			var authToken = await this._userManager.LoginAsync(user);
			if(authToken is null)
			{
				return Ok(new { Alert = Config.InvalidAuth });
			}

			return Ok(new { Token = authToken });
		}

	}
}
