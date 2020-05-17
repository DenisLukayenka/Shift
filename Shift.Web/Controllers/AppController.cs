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
    }
}