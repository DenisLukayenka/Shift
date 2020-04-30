using System;
using System.Linq;
using System.Linq.Expressions;

namespace Shift.Services.Services.Repositories.Interfaces
{
	public interface IRepository<T> where T: class
	{
		IQueryable<T> GetAll();
		IQueryable<T> Get(Expression<Func<T, bool>> expression);

		void Add(T entity);
		void Update(T entity);
		void Delete(T entity);
	}
}
