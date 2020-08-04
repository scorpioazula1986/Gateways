using MediatR;
using Musala.Gateways.Core.Responses;

namespace Musala.Gateways.Application.Device.Command.DeleteDevice
{
    public class DeleteDeviceCommand:IRequest<ApiResponse>
    {
        public  long Id { get; set; }
    }
}