using Shift.Infrastructure.Models;

namespace Shift.Infrastructure.Responses
{
	public class RootMenuResponse: BaseResponse
	{
		public RootMenuResponse() { }

		public override string Type { get; } = "RootMenuResponse";

		public RootMenu RootMenu { get; set; }
	}
}
