
using Microsoft.EntityFrameworkCore;

using System;
using System.Linq;
using System.Linq.Expressions;

namespace Shift.Repository.Repositories.Implementations
{
	using Shift.Repository.Database;
	using Shift.Repository.Repositories.Interfaces;

	public abstract class BaseRepository<T> : IRepository<T> where T: class
	{
		protected CoreContext AppContext { get; set; }

		public BaseRepository(CoreContext context)
		{
			this.AppContext = context;
		}

		public virtual IQueryable<T> GetAll()
		{
			return this.AppContext.Set<T>().AsNoTracking();
		}

		public virtual IQueryable<T> Get(Expression<Func<T, bool>> expression)
		{
			return this.AppContext.Set<T>().Where(expression).AsNoTracking();
		}

		public virtual T Add(T entity)
		{
			return this.AppContext.Set<T>().Add(entity)?.Entity;
		}

		public virtual T Delete(T entity)
		{
			return this.AppContext.Set<T>().Remove(entity).Entity;
		}

		public virtual T Update(T entity)
		{
			return this.AppContext.Set<T>().Update(entity).Entity;
		}
	}
}
