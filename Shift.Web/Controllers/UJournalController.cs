﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shift.Infrastructure.Models.SharedData;
using Shift.Infrastructure.Models.ViewModels.Journals;
using Shift.Services.Managers.Journals.UJournals;

namespace Shift.Web.Controllers
{
    [Route("api/undergraduate/journal")]
    [Authorize(Roles = RoleNames.Undergraduate)]
    [ApiController]
    public class UJournalController : ControllerBase
    {
        private readonly IUJournalManager _journalManager;

        public UJournalController(IUJournalManager manager)
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
        public IActionResult Post([FromBody] UJournal journal)
        {
            this._journalManager.SaveJournal(journal);

            return Ok(new { Message = Config.SaveSuccess });
        }
    }
}