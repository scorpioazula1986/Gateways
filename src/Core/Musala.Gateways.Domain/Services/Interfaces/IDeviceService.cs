using System.Collections.Generic;
using Musala.Gateways.Data.Database;
using Musala.Gateways.Domain.Services.Base;

namespace Musala.Gateways.Domain.Services.Interfaces
{
    public interface IDeviceService:IBaseService<DatDevice, long>
    {
    }
}