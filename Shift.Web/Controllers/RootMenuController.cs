using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shift.Infrastructure.Requests;
using Shift.Services.Services.Menu;

namespace Shift.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RootMenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public RootMenuController(IMenuService menuService)
        {
            this._menuService = menuService;
        }

        [Authorize(Roles = "undergraduate")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] RootMenuRequest request)
        {
            var menu = this._menuService.GetRootMenu(request.Role);

            return Ok(new { RootMenu = menu });
        }
    }
}