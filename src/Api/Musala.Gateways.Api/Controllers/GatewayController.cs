using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Musala.Gateways.Api.Controllers.Base;
using Musala.Gateways.Application.Gateway.Command.AddGateway;
using Musala.Gateways.Application.Gateway.Command.UpdateGateway;
using Musala.Gateways.Application.Gateway.Query.GetAllGateways;
using Musala.Gateways.Application.Gateway.Query.GetDevices;
using Musala.Gateways.Application.Gateway.Query.GetGateway;

namespace Musala.Gateways.Api.Controllers
{
    [ApiController]
    [Route("api/gateways")]

    public class GatewayController:BaseController
    {
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var request=new GetGatewayQuery();
            request.Id = id;
            return Ok(await Mediator.Send(request));
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var request=new GetAllGatewaysQuery();
            return Ok(await Mediator.Send(request));
        }

        [HttpGet("{id}/devices")]
        public async Task<IActionResult> GetDevices(long id)
        {
            var request=new GetDevicesQuery();
            request.Id=id;
            return Ok(await Mediator.Send(request));
        }
        [HttpPost]
        public async Task<IActionResult> Post(AddGatewayCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id,UpdateGatewayCommand request)
        {
            request.Id = id;
            return Ok(await Mediator.Send(request));
        }

        
    }
}