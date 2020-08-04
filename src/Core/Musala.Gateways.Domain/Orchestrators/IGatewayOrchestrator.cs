using System.Collections.Generic;
using System.Threading.Tasks;
using Musala.Gateways.Domain.Models;

namespace Musala.Gateways.Domain.Orchestrators
{
    public interface IGatewayOrchestrator
    {
        Task AddGateway(GatewayModel model);
        Task UpdateGateway(long id,GatewayModel model);
        Task DeleteGateway(long id);
        Task<object> GetGateway(long id);
        Task<IEnumerable<object>> GetAllGateways();
        Task<IEnumerable<object>> GetDevices(long idGateway);
    }
}