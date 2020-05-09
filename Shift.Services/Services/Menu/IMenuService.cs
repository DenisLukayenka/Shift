using Shift.Infrastructure.Models.ViewModels.SiteConfig;

namespace Shift.Services.Services.Menu
{
	public interface IMenuService
	{
		RootMenu GetRootMenu(string type);
	}
}
