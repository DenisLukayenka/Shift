namespace Shift.Infrastructure.Requests
{
	public class RootMenuRequest: BaseRequest
	{
		public string Role { get; set; }

		public override string Type => "RootMenuRequest";
	}
}
