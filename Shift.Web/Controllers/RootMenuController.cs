using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shift.Services.Managers.User;
using Shift.Services.Services.Menu;

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
        public IActionResult Get([FromQuery] int userId)
        {
            var userRole = this._userManager.FetchUserRole(userId);
            var menu = this._menuService.GetRootMenu(userRole);

            return Ok(new { RootMenu = menu, Role = userRole });
        }
    }
}