using System.Collections.Generic;

namespace Shift.Infrastructure.Models.ViewModels.SiteConfig
{
	public class MenuGroup
	{
		public string Caption { get; set; }

		public ICollection<MenuItem> Items { get; set; } = new List<MenuItem>();
	}
}
