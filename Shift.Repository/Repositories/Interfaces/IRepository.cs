using System;
using System.Linq;
using System.Linq.Expressions;

namespace Shift.Repository.Repositories.Interfaces
{
	public interface IRepository<T> where T: class
	{
		IQueryable<T> GetAll();
		IQueryable<T> Get(Expression<Func<T, bool>> expression);

		T Add(T entity);
		T Update(T entity);
		T Delete(T entity);
	}
}
