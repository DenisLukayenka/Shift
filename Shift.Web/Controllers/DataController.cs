﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shift.DAL.Models.UserModels.EmployeeData;
using Shift.Infrastructure.Models.ViewModels.Data;
using Shift.Repository.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Shift.Web.Controllers
{
	[Route("api/data")]
	[ApiController]
	public class DataController: ControllerBase
	{
		private IRepositoryWrapper _repository;
		private IMapper _mapper;

		public DataController(IRepositoryWrapper repository, IMapper mapper)
		{
			this._repository = repository;
			this._mapper = mapper;
		}

		[HttpGet]
		[Route("degrees")]
		public IActionResult GetDegrees()
		{
			var degreesDb = this._repository.Degrees.GetAll().ToList();
			var degrees = this._mapper.Map<IEnumerable<AcademicDegreeVM>>(degreesDb);

			return Ok(degrees);
		}

		[HttpGet]
		[Route("ranks")]
		public IActionResult GetRanks()
		{
			var ranksDb = this._repository.Ranks.GetAll();
			var ranks = this._mapper.Map<IEnumerable<AcademicRankVM>>(ranksDb);

			return Ok(ranks);
		}

		[HttpGet]
		[Route("positions")]
		public IActionResult GetPositions()
		{
			var positionsDb = this._repository.Positions.GetAll();
			var positions = this._mapper.Map<IEnumerable<JobPositionVM>>(positionsDb);

			return Ok(positions);
		}
	}
}
