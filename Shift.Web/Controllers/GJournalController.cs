using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shift.Infrastructure;
using Shift.Infrastructure.Models.SharedData;
using Shift.Infrastructure.Models.ViewModels.Journals;
using Shift.Services.Managers.Journals.GJournals;

namespace Shift.Web.Controllers
{
    [Route("api/graduate/journal")]
    [Authorize(Roles = RoleNames.Graduate)]
    [ApiController]
    public class GJournalController : ControllerBase
    {
        private readonly IGJournalManager _journalManager;

        public GJournalController(IGJournalManager manager)
        {
            this._journalManager = manager;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] int userId)
        {
           var journal = this._journalManager.FetchJournal(userId);

            if (journal != null)
            {
                return Ok(new { Journal = journal });
            }

            return Ok(new { Alert = Config.BadRequest });
        }

        [HttpPost]
        public IActionResult Post([FromBody] GJournal journal)
        {
            this._journalManager.SaveJournal(journal);

            return Ok(new { Message = Config.SaveSuccess });
        }
    }
}