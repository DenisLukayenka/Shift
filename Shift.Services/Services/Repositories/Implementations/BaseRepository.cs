
using Microsoft.EntityFrameworkCore;
using Shift.Services.Contexts;
using Shift.Services.Services.Repositories.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Shift.Services.Services.Repositories.Implementations
{
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


		public virtual void Add(T entity)
		{
			this.AppContext.Set<T>().Add(entity);
		}

		public virtual void Delete(T entity)
		{
			this.AppContext.Set<T>().Remove(entity);
		}

		public virtual void Update(T entity)
		{
			this.AppContext.Set<T>().Update(entity);
		}
	}
}
