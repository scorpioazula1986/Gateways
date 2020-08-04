using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Musala.Gateways.Core.Responses;
using Musala.Gateways.Domain.Orchestrators;

namespace Musala.Gateways.Application.Device.Query.GetDevice
{
    public class GetDeviceQueryHandler:IRequestHandler<GetDeviceQuery,ApiResponse>
    {
        private readonly IDeviceOrchestrator _deviceOrchestrator;

        public GetDeviceQueryHandler(IDeviceOrchestrator deviceOrchestrator)
        {
            _deviceOrchestrator = deviceOrchestrator;
        }
        public async Task<ApiResponse> Handle(GetDeviceQuery request, CancellationToken cancellationToken)
        {
            var response=new ApiResponse();
            response.Data = await _deviceOrchestrator.GetDevice(request.Id);
            return response;
        }
    }
}