using Shift.Infrastructure.Models.ViewModels.SiteConfig;
using System;

namespace Shift.Services.Services.Menu
{
	public class MenuService : IMenuService
	{
		public RootMenu GetRootMenu(string type)
		{
			return type switch
			{
				"undergraduate" => this.GenerateUndergraduateMenu(),
				"graduate" => this.GenerateGraduateMenu(),
				"employee" => this.GenerateEmployeeMenu(),
				_ => throw new Exception(),
			};
		}

		private RootMenu GenerateUndergraduateMenu()
		{
			return new RootMenu
			{
				MenuGroups =
				{
					new MenuGroup
					{
						Caption = "Учёт работы",
						Items =
						{
							new MenuItem
							{
								Caption = "План работы",
								Icon = "book",
								Link = "uj"
							},
							new MenuItem
							{
								Caption = "Результаты",
								Icon = "assignment",
								Link = "uj-results"
							}
						},
					},
				},
			};
		}

		private RootMenu GenerateGraduateMenu()
		{
			return new RootMenu
			{
				MenuGroups =
				{
					new MenuGroup
					{
						Caption = "Учёт работы",
						Items =
						{
							new MenuItem
							{
								Caption = "План работы",
								Icon = "book",
								Link = "gj"
							},
							new MenuItem
							{
								Caption = "Результаты",
								Icon = "assignment",
								Link = "gj-results"
							}
						},
					},
				},
			};
		}

		private RootMenu GenerateEmployeeMenu()
		{
			return new RootMenu
			{
				MenuGroups =
				{
					new MenuGroup
					{
						Caption = "Магистранты",
						Items =
						{
							new MenuItem
							{
								Caption = "Список",
								Icon = "view_list",
								Link = "u-list"
							},
							new MenuItem
							{
								Caption = "Планы работ",
								Icon = "assignment",
								Link = "uj-list"
							}
						},
					},
					new MenuGroup
					{
						Caption = "Аспиранты",
						Items =
						{
							new MenuItem
							{
								Caption = "Список",
								Icon = "view_list",
								Link = "g-list"
							},
							new MenuItem
							{
								Caption = "Планы работ",
								Icon = "assignment",
								Link = "gj-list"
							}
						},
					},
				},
			};
		}
	}
}
