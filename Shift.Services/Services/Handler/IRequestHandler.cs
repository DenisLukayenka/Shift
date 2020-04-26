using Shift.Infrastructure.Requests;
using Shift.Infrastructure.Responses;

namespace Shift.Services.Services.Handler
{
	public interface IRequestHandler
	{
		BaseResponse Process(BaseRequest request);
	}
}
