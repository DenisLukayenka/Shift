using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shift.Infrastructure.Models.SharedData;
using Shift.Infrastructure.Models.ViewModels.Journals;
using Shift.Services.Managers.Journals.UJournals;
using System.IO;

namespace Shift.Web.Controllers
{
    [Route("api/undergraduate/journal")]
    [Authorize]
    [ApiController]
    public class UJournalController : ControllerBase
    {
        private readonly IUJournalManager _journalManager;

        public UJournalController(IUJournalManager manager)
        {
            this._journalManager = manager;
        }

        [HttpGet]
        [Authorize]
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

            return File(journalBytes, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "UndergraduateTemplate.docx");
        }

        [HttpPost]
        public IActionResult Post([FromBody] UJournalVM journal)
        {
            var savedJournal = this._journalManager.SaveJournal(journal);

            return Ok(new { Message = Config.SaveSuccess, Journal = savedJournal });
        }
    }
}