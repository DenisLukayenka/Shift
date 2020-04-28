using Shift.Services.Contexts;
using Shift.Services.Services.Repositories.Implementations;
using Shift.Services.Services.Repositories.Interfaces;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shift.Services.Services.Repositories
{
	public class RepositoryWrapper : IRepositoryWrapper
	{
		private readonly CoreContext _dbContext;
		private IUserRepository _userRepository;

		public RepositoryWrapper(CoreContext repositoryContext)
		{
			this._dbContext = repositoryContext;
		}

		public IUserRepository Users 
		{ 
			get 
			{
				if(this._userRepository is null)
				{
					this._userRepository = new UserRepository(this._dbContext);
				}

				return this._userRepository;
			}
		}

		public async Task SaveAsync()
		{
			await this._dbContext.SaveChangesAsync();
		}
	}
}
