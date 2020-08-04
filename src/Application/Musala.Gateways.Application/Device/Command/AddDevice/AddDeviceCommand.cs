using MediatR;
using Musala.Gateways.Core.Responses;
using Musala.Gateways.Domain.Models;

namespace Musala.Gateways.Application.Device.Command.AddDevice
{
    public class AddDeviceCommand:IRequest<ApiResponse>
    {
        public  DeviceModel Device { get; set; }
    }
}