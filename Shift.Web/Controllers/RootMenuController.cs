﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shift.Infrastructure.Requests;
using Shift.Services.Services.RequestProcessor;

namespace Shift.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RootMenuController : ControllerBase
    {
        private readonly IRequestProcessorAsync _processor;

        public RootMenuController(IRequestProcessorAsync processor)
        {
            this._processor = processor;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] RootMenuRequest request)
        {
            var response = await this._processor.PerformAsync(request);

            return Ok(response);
        }
    }
}