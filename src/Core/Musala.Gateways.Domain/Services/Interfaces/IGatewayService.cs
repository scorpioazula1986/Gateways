using System.Threading.Tasks;
using Musala.Gateways.Data.Database;
using Musala.Gateways.Domain.Services.Base;

namespace Musala.Gateways.Domain.Services.Interfaces
{
    public interface IGatewayService:IBaseService<DatGateway, long>
    {
        Task<bool> IsFull(long id);
        Task<DatGateway> GetGateway(long id);
    }
}