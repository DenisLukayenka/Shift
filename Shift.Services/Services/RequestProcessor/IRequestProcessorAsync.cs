using Shift.Infrastructure.Requests;
using Shift.Infrastructure.Responses;
using System.Threading.Tasks;

namespace Shift.Services.Services.RequestProcessor
{
	public interface IRequestProcessorAsync
	{
		Task<BaseResponse> PerformAsync(BaseRequest request);
	}
}
