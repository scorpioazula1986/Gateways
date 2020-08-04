using Musala.Gateways.Domain.Services.Base;
using Musala.Gateways.Domain.Services.Interfaces;
using Musala.Gateways.Data.Database;

namespace Musala.Gateways.Persistence.Services
{
    public class DeviceService:BaseService<DatDevice,long>,IDeviceService
    {
        public DeviceService(GatewayContext context) : base(context)
        {
            DataHolder = context.DatDevice;
        }
    }
}