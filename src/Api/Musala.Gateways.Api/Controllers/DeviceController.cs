using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Musala.Gateways.Api.Controllers.Base;
using Musala.Gateways.Application.Device.Command.AddDevice;
using Musala.Gateways.Application.Device.Command.DeleteDevice;
using Musala.Gateways.Application.Device.Query.GetDevice;
using Musala.Gateways.Application.Gateway.Query.GetAllGateways;

namespace Musala.Gateways.Api.Controllers
{
    [ApiController]
    [Route("api/devices")]
    public class DeviceController : BaseController
    {
        
        
        [HttpPost]
        public async Task<IActionResult> Post(AddDeviceCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
        
       
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var request=new DeleteDeviceCommand();
            request.Id = id;
            return Ok(await Mediator.Send(request));
        }
    }
}