using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shift.Infrastructure.Models.SharedData;
using Shift.Services.Managers.User;

namespace Shift.Web.Controllers
{
    [Route("api/app")]
    [ApiController]
    public class AppController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public AppController(IUserManager userManager)
        {
            this._userManager = userManager;
        }

        [Authorize]
        [HttpGet]
        [Route("defaultRoute")]
        public IActionResult Get([FromQuery] int userId)
        {
            string role = this._userManager.FetchUserRole(userId);

            string defaultRoute = role switch
            {
                RoleNames.Graduate => "gj",
                RoleNames.Employee => "em",
                RoleNames.Undergraduate => "uj",
                _ => throw new NotImplementedException(),
            };

            return Ok(new { DefaultRoute = defaultRoute });
        }
    }
}