using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Musala.Gateways.Domain.Services.Base;
using Musala.Gateways.Domain.Services.Interfaces;
using Musala.Gateways.Data.Database;

namespace Musala.Gateways.Persistence.Services
{
    public class GatewayService:BaseService<DatGateway,long>,IGatewayService
    {
        public GatewayService(GatewayContext context) : base(context)
        {
            DataHolder = context.DatGateway;
        }

        public async Task<bool> IsFull(long id)
        {
            var gt=await DataHolder.Include(e => e.DatDevice).FirstOrDefaultAsync(e => e.Id == id);
            return gt.DatDevice.Count >= 10;
        }

        public async Task<DatGateway> GetGateway(long id)
        {
            return await DataHolder.Include(e => e.DatDevice).FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}