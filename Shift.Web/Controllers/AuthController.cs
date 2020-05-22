using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shift.Infrastructure.Models.SharedData;
using Shift.Infrastructure.Models.ViewModels.Auth;
using Shift.Services.Managers.User;
using Shift.Services.Providers.Token;

namespace Shift.Web.Controllers
{
	[Route("api/auth")]
	[ApiController]
	public class AuthController: ControllerBase
	{
		private readonly IUserManager _userManager;
		private readonly ITokenProvider _tokenProvider;

		public AuthController(IUserManager userManager, ITokenProvider tokenProvider)
		{
			this._userManager = userManager;
			this._tokenProvider = tokenProvider;
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("login")]
		public IActionResult Login([FromBody] LoginVM user)
		{
			if(user is null)
			{
				return Ok(new { Alert = Config.BadRequest });
			}
			var authContext = this._userManager.Login(user);

			if(authContext.User != null)
			{
				authContext.Token = this._tokenProvider.GenerateToken(authContext.User.Login, authContext.User.Role);

				return Ok(authContext);
			}

			return Ok(authContext);
		}

		[HttpPut]
		[AllowAnonymous]
		[Route("register/undergraduate")]
		public IActionResult RegisterUndergraduate([FromBody] UndergraduateRegisterVM undergraduate)
		{
			if(undergraduate is null)
			{
				return Ok(new { Alert = Config.BadRequest });
			}

			var authContext = this._userManager.RegisterUndergraduate(undergraduate);
			if(authContext.User != null)
			{
				authContext.Token = this._tokenProvider.GenerateToken(authContext.User.Login, authContext.User.Role);
				return Ok(authContext);
			}

			return Ok(authContext);
		}

		[HttpPut]
		[AllowAnonymous]
		[Route("register/graduate")]
		public IActionResult RegisterGraduate([FromBody] GraduateViewModel graduate)
		{
			if (graduate is null)
			{
				return Ok(new { Alert = Config.BadRequest });
			}

			var authContext = this._userManager.RegisterGraduate(graduate);
			if (authContext.User != null)
			{
				authContext.Token = this._tokenProvider.GenerateToken(authContext.User.Login, authContext.User.Role);
				return Ok(authContext);
			}

			return Ok(authContext);
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("register/employee")]
		public IActionResult RegisterEmployee([FromBody] EmployeeRegisterVM employee)
		{
			if (employee is null)
			{
				return Ok(new { Alert = Config.BadRequest });
			}

			var authContext = this._userManager.RegisterEmployee(employee);
			if (authContext.User != null)
			{
				authContext.Token = this._tokenProvider.GenerateToken(authContext.User.Login, authContext.User.Role);
				return Ok(authContext);
			}

			return Ok(authContext);
		}
	}
}
