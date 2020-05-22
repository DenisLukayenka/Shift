using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shift.Infrastructure.Models.ViewModels.Data;
using Shift.Infrastructure.Models.ViewModels.University;
using Shift.Infrastructure.Models.ViewModels.Users;
using Shift.Repository.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Shift.Web.Controllers
{
	[Route("api/data")]
	[ApiController]
	public class DataController: ControllerBase
	{
		private readonly IRepositoryWrapper _repository;
		private readonly IMapper _mapper;

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

		[HttpGet]
		[Route("departments")]
		public IActionResult GetDepartments()
		{
			var departmentsDb = this._repository.Departments.GetAll();
			var departments = this._mapper.Map<IEnumerable<DepartmentVM>>(departmentsDb);

			return Ok(departments);
		}

		[HttpGet]
		[Route("specialties")]
		public IActionResult GetSpecialties()
		{
			var specialtiesDb = this._repository.Specialties.GetAll();
			var specialties = this._mapper.Map<IEnumerable<SpecialtyVM>>(specialtiesDb);

			return Ok(specialties);
		}

		[HttpGet]
		[Route("adviserList")]
		public IActionResult GetEmployeeList()
		{
			var employeesDb = this._repository.Employees.GetAdvisersList();
			var employees = this._mapper.Map<IEnumerable<AdviserListItem>>(employeesDb);

			return Ok(employees);
		}
	}
}
