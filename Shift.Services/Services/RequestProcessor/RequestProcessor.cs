using Shift.Infrastructure.Requests;
using Shift.Infrastructure.Responses;
using Shift.Services.Services.Handler;
using System.Threading.Tasks;

namespace Shift.Services.Services.RequestProcessor
{
	public class RequestProcessor : IRequestProcessorAsync
	{
		private readonly IRequestHandler _handler;

		public RequestProcessor(IRequestHandler handler)
		{
			this._handler = handler;
		}

		public async Task<BaseResponse> PerformAsync(BaseRequest request)
		{
			return await Task.Factory.StartNew<BaseResponse>(() => this._handler.Process(request));
		}
	}
}
