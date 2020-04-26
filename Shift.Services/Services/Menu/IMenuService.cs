using Shift.Infrastructure.Models;

namespace Shift.Services.Services.Menu
{
	public interface IMenuService
	{
		RootMenu GetRootMenu(string type);
	}
}
