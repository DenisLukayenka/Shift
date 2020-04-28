
using Microsoft.EntityFrameworkCore;
using Shift.Services.Contexts;
using Shift.Services.Services.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CoreContext = Shift.Services.Contexts.CoreContext;

namespace Shift.Services.Services.Repositories.Implementations
{
	public abstract class BaseRepository<T> : IRepositoryAsync<T> where T: class
	{
		protected CoreContext AppContext { get; set; }

		public BaseRepository(CoreContext context)
		{
			this.AppContext = context;
		}

		public async Task<IQueryable<T>> GetAllAsync()
		{
			return this.AppContext.Set<T>().AsNoTracking();
		}

		public async Task<IQueryable<T>> GetAsync(Expression<Func<T, bool>> expression)
		{
			return this.AppContext.Set<T>().Where(expression).AsNoTracking();
		}


		public async Task AddAsync(T entity)
		{
			await this.AppContext.Set<T>().AddAsync(entity);
		}

		public async Task DeleteAsync(T entity)
		{
			this.AppContext.Set<T>().Remove(entity);
		}

		public async Task UpdateAsync(T entity)
		{
			this.AppContext.Set<T>().Update(entity);
		}
	}
}
