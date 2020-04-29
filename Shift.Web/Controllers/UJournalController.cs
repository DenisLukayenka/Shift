using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shift.Infrastructure;
using Shift.Infrastructure.Models;

namespace Shift.Web.Controllers
{
    [Route("api/undergraduate/journal")]
    [Authorize(Roles = RoleNames.Undergraduate)]
    [ApiController]
    public class UJournalController : ControllerBase
    {
    }
}