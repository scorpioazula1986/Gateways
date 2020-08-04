using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Musala.Gateways.Domain.Models;

namespace Musala.Gateways.Domain.Orchestrators
{
    public interface IDeviceOrchestrator
    {
        Task AddDevice(DeviceModel model);
        Task UpdateDevice(long id,DeviceModel model);
        Task DeleteDevice(long id);
        Task<object> GetDevice(long id);
        Task<IEnumerable<object>> GetAllDevices();
    }
}