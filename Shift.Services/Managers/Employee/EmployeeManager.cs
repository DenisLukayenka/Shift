using AutoMapper;
using Shift.Infrastructure.Models.ViewModels.Users;
using Shift.Repository.Repositories;
using System.Collections.Generic;

namespace Shift.Services.Managers.Employee
{
	public class EmployeeManager : IEmployeeManager
	{
		private readonly IRepositoryWrapper _repository;
		private readonly IMapper _mapper;

		public EmployeeManager(IRepositoryWrapper repository, IMapper mapper)
		{
			this._repository = repository;
			this._mapper = mapper;
		}

		public IEnumerable<GraduateContext> GetGraduates(int employeeId)
		{
			var graduatesDb = this._repository.Graduates.Get(g => g.ScienceAdviserId == employeeId);
			var graduateContexts = this._mapper.Map<IEnumerable<GraduateContext>>(graduatesDb);

			return graduateContexts;
		}

		public IEnumerable<UndergraduateContext> GetUndergraduates(int employeeId)
		{
			var undergraduatesDb = this._repository.Undergraduates.Get(g => g.ScienceAdviserId == employeeId);
			var undergraduateContexts = this._mapper.Map<IEnumerable<UndergraduateContext>>(undergraduatesDb);

			return undergraduateContexts;
		}

		public IEnumerable<AdviserListItem> GetAdvisersList()
		{
			var employeesDb = this._repository.Employees.GetAdvisersList();
			return this._mapper.Map<IEnumerable<AdviserListItem>>(employeesDb);
		}
	}
}
