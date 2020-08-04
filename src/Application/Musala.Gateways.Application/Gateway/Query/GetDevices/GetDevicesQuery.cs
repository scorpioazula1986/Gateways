using MediatR;
using Musala.Gateways.Core.Responses;

namespace Musala.Gateways.Application.Gateway.Query.GetDevices
{
    public class GetDevicesQuery:IRequest<ApiResponse>
    {
        public long Id{get; set;}
    }
}
