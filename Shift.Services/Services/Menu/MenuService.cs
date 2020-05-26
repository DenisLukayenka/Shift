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
								Link = "undergraduate/uj"
							},
							new MenuItem
							{
								Caption = "Выход",
								Icon = "exit_to_app",
								Link = "logout"
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
								Link = "graduate/gj"
							},
							new MenuItem
							{
								Caption = "Выход",
								Icon = "exit_to_app",
								Link = "logout"
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
						Caption = "Планы работ",
						Items =
						{
							new MenuItem
							{
								Caption = "Магистранты",
								Icon = "assignment",
								Link = "employee/uj-list"
							},
							new MenuItem
							{
								Caption = "Аспиранты",
								Icon = "assignment",
								Link = "employee/gj-list"
							},
							new MenuItem
							{
								Caption = "Выход",
								Icon = "exit_to_app",
								Link = "logout"
							}
						},
					},
				},
			};
		}
	}
}
