using System.Collections.Generic;

namespace Shift.Infrastructure.Models
{
	public class RootMenu
	{
		public ICollection<MenuGroup> MenuGroups { get; set; } = new List<MenuGroup>();
	}
}
