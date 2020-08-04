using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.VisualBasic;
using Musala.Gateways.Core.Exceptions.Common;
using Musala.Gateways.Core.Exceptions.Gateway;
using Musala.Gateways.Data.Database;
using Musala.Gateways.Domain.Models;
using Musala.Gateways.Domain.Orchestrators.Base;
using Musala.Gateways.Domain.Services.Interfaces;
using Constants = Musala.Gateways.Core.Constants.Constants;

namespace Musala.Gateways.Domain.Orchestrators
{
    public class DeviceOrchestrator:BaseOrchestrator, IDeviceOrchestrator
    {
        private readonly IDeviceService _service;
        private readonly IGatewayService _gatewayService;
        public DeviceOrchestrator(IDeviceService service,IGatewayService gatewayService,IMapper mapper) : base(mapper)
        {
            _service = service;
            _gatewayService = gatewayService;
        }

        public async Task AddDevice(DeviceModel model)
        {
            var gt = await _gatewayService.GetByIdAsync(model.IdGateway);
            if(gt==null) throw new NotFoundException(Constants.Resources.Gateway);
            var full = await _gatewayService.IsFull(gt.Id);
            if(full) throw new FullGatewayException();
            var entity = Mapper.Map<DatDevice>(model);
            await _service.CreateAsync(entity);
        }

        public async Task UpdateDevice(long id,DeviceModel model)
        {
            var entity = await _service.GetByIdAsync(id);
            if(entity==null) throw new NotFoundException(Constants.Resources.Device);
            Mapper.Map(model, entity);
            await _service.UpdateAsync(entity);
        }

        public async Task DeleteDevice(long id)
        {
            var entity = await _service.GetByIdAsync(id);
            if(entity==null) throw new NotFoundException(Constants.Resources.Device);
            await _service.DeleteAsync(entity);
        }

        public async Task<object> GetDevice(long id)
        {
            var entity = await _service.GetByIdAsync(id);
            if(entity==null) throw new NotFoundException(Constants.Resources.Device);
            return new
            {
                Id = entity.Id,
                Uid = entity.NumUid,
                Status = (entity.FlgStatus == 1) ? "Online" : "Offline",
                Vendor = entity.DesVendor

            };
        }

        public async Task<IEnumerable<object>> GetAllDevices()
        {
            var list = await _service.GetAll();
            return list.Select(l => new { Id = l.Id, Uid = l.NumUid, Status = (l.FlgStatus == 1) ? "Online" : "Offline",
                Vendor=l.DesVendor }).Cast<dynamic>().ToList();

        }

        
    }
}