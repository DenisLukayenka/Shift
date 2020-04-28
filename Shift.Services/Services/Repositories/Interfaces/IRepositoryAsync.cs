using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shift.Services.Services.Repositories.Interfaces
{
	public interface IRepositoryAsync<T> where T: class
	{
		Task<IQueryable<T>> GetAllAsync();
		Task<IQueryable<T>> GetAsync(Expression<Func<T, bool>> expression);

		Task AddAsync(T entity);
		Task UpdateAsync(T entity);
		Task DeleteAsync(T entity);
	}
}
