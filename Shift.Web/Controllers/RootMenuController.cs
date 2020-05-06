using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shift.Infrastructure.Models;
using Shift.Infrastructure.Requests;
using Shift.Services.Managers.User;
using Shift.Services.Services.Menu;
using System;

namespace Shift.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RootMenuController : ControllerBase
    {
        private readonly IMenuService _menuService;
        private readonly IUserManager _userManager;

        public RootMenuController(IMenuService menuService, IUserManager userManager)
        {
            this._menuService = menuService;
            this._userManager = userManager;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] RootMenuRequest request)
        {
            var userRole = this._userManager.FetchUserRole(request.UserId);
            var menu = this._menuService.GetRootMenu(userRole);

            return Ok(new { RootMenu = menu, Role = userRole });
        }
    }
}