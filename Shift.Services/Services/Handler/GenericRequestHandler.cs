using Shift.Infrastructure.Requests;
using Shift.Infrastructure.Responses;
using Shift.Services.Services.Menu;
using System;

namespace Shift.Services.Services.Handler
{
	public class GenericRequestHandler : IRequestHandler
	{
		private readonly IMenuService _menuService;

		public GenericRequestHandler(IMenuService menuService)
		{
			this._menuService = menuService;
		}

		public BaseResponse Process(BaseRequest request)
		{
			return request switch
			{
				RootMenuRequest r => this.Execute(r),
				_ => throw new Exception(),
			};
		}

		protected virtual RootMenuResponse Execute(RootMenuRequest req)
		{
			var menu = this._menuService.GetRootMenu(req.Role);

			return new RootMenuResponse
			{
				RootMenu = menu
			};
		}
	}
}
