using MediatR;
using Musala.Gateways.Core.Responses;

namespace Musala.Gateways.Application.Device.Query.GetDevice
{
    public class GetDeviceQuery:IRequest<ApiResponse>
    {
        public long Id { get; set; }
    }
}