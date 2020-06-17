using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shift.Infrastructure.Models.SharedData;
using Shift.Infrastructure.Models.ViewModels.Journals;
using Shift.Services.Managers.Journals.GJournals;
using System.IO;

namespace Shift.Web.Controllers
{
    [Route("api/graduate/journal")]
    [Authorize]
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

        [HttpGet]
        [Route("downloadJournal")]
        [Authorize]
        public IActionResult DownloadJournal([FromQuery] int userId)
        {
            var journalBytes = this._journalManager.DownloadJournalDocx(userId);
            var content = new MemoryStream(journalBytes);

            return File(content, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "GraduateTemplate.docx");
        }

        [HttpPost]
        public IActionResult Post([FromBody] GJournal journal)
        {
            var savedJournal = this._journalManager.SaveJournal(journal);

            return Ok(new { Message = Config.SaveSuccess, Journal = savedJournal });
        }
    }
}