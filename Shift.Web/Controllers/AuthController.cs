using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shift.Infrastructure;
using Shift.Infrastructure.Models;
using Shift.Infrastructure.Models.ViewModels.Auth;
using Shift.Services.Managers.User;
using Shift.Services.Providers.Token;

namespace Shift.Web.Controllers
{
	[Route("api/auth")]
	[ApiController]
	public class AuthController: ControllerBase
	{
		private readonly IUserManagerAsync _userManager;
		private readonly ITokenProvider _tokenProvider;

		public AuthController(IUserManagerAsync userManager, ITokenProvider tokenProvider)
		{
			this._userManager = userManager;
			this._tokenProvider = tokenProvider;
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("login")]
		public async Task<IActionResult> Login([FromBody] LoginViewModel user)
		{
			if(user is null)
			{
				return Ok(new { Alert = Config.BadRequest });
			}

			var role = await this._userManager.LoginAsync(user);
			if(role is null)
			{
				return Ok(new { Alert = Config.InvalidAuth });
			}
			var token = this._tokenProvider.GenerateToken(user.Login, role);

			return Ok(new { Token = token });
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("register/undergraduate")]
		public async Task<IActionResult> RegisterUndergraduate([FromBody] UndergraduateViewModel undergraduate)
		{
			if(undergraduate is null)
			{
				return Ok(new { Alert = Config.BadRequest });
			}

			var alerts = await this._userManager.RegisterUndergraduateAsync(undergraduate);
			if(alerts != null)
			{
				return Ok(new { Alert = alerts });
			}

			var token = this._tokenProvider.GenerateToken(undergraduate.Login, RoleNames.Undergraduate);

			return Ok(new { Token = token });
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("register/graduate")]
		public async Task<IActionResult> RegisterGraduate([FromBody] GraduateViewModel graduate)
		{
			if (graduate is null)
			{
				return Ok(new { Alert = Config.BadRequest });
			}

			var alerts = await this._userManager.RegisterGraduateAsync(graduate);
			if (alerts != null)
			{
				return Ok(new { Alert = alerts });
			}

			var token = this._tokenProvider.GenerateToken(graduate.Login, RoleNames.Graduate);

			return Ok(new { Token = token });
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("register/employee")]
		public async Task<IActionResult> RegisterEmployee([FromBody] EmployeeViewModel employee)
		{
			if (employee is null)
			{
				return Ok(new { Alert = Config.BadRequest });
			}

			var alerts = await this._userManager.RegisterEmployeeAsync(employee);
			if (alerts != null)
			{
				return Ok(new { Alert = alerts });
			}

			var token = this._tokenProvider.GenerateToken(employee.Login, RoleNames.Employee);

			return Ok(new { Token = token });
		}
	}
}
