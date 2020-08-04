using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Musala.Gateways.Core.Constants;
using Musala.Gateways.Core.Exceptions.Common;
using Musala.Gateways.Core.Exceptions.Gateway;
using Musala.Gateways.Data.Database;
using Musala.Gateways.Domain.Models;
using Musala.Gateways.Domain.Orchestrators.Base;
using Musala.Gateways.Domain.Services.Interfaces;

namespace Musala.Gateways.Domain.Orchestrators
{
    public class GatewayOrchestrator :BaseOrchestrator, IGatewayOrchestrator
    {
        private readonly IGatewayService _service;
        public GatewayOrchestrator(IGatewayService service,IMapper mapper) : base(mapper)
        {
            _service=service;
        }

        public async Task AddGateway(GatewayModel model)
        {
           if(!ValidateIpv4(model.Ipv4)) throw new InvalidIpv4Exception();
           var entity=Mapper.Map<DatGateway>(model);
           await _service.CreateAsync(entity);
        }

        public async Task DeleteGateway(long id)
        {
           var entity=await _service.GetByIdAsync(id);
           if(entity==null) throw new NotFoundException(Constants.Resources.Gateway);
           await _service.DeleteAsync(entity);
        }

        public async Task<IEnumerable<object>> GetAllGateways()
        {
            var list= await _service.GetAll();
            return list.Select(l => new { Id = l.Id, Name = l.DesName.ToUpper(), Ipv4 = l.DesIpv4,SerialNumber=l.DesSerialNumber }).Cast<dynamic>().ToList();

        }

        public async Task<IEnumerable<object>> GetDevices(long idGateway)
        {
            var gt= await _service.GetGateway(idGateway);
            if(gt==null) throw new NotFoundException(Constants.Resources.Gateway);
            var devices=gt.DatDevice.Select(l=>new{Id=l.Id,Uid=l.NumUid,Vendor=l.DesVendor,Status=l.FlgStatus});
            return devices;
        }

        public async Task<object> GetGateway(long id)
        {
            var entity=await _service.GetGateway(id);
            if(entity==null) throw new NotFoundException(Constants.Resources.Gateway);
            return new{
                Id=entity.Id,
                SerialNumber=entity.DesSerialNumber,
                Ipv4=entity.DesIpv4,
                Name=entity.DesName,
                Devices=entity.DatDevice.Count(),
              

            };

        }

        public async Task UpdateGateway(long id, GatewayModel model)
        {
            var entity=await _service.GetByIdAsync(id);
            if(entity==null) throw new NotFoundException(Constants.Resources.Gateway);
            Mapper.Map(model, entity);
            await _service.UpdateAsync(entity);
         
        }

        private bool ValidateIpv4(string ip)
        {
            if(string.IsNullOrWhiteSpace(ip)) return false;
            var splitValues=ip.Split('.');
            if(splitValues.Length!=4) return false;
            byte tempForParsing;
            return splitValues.All(r=>byte.TryParse(r,out tempForParsing));
        }
    }
}