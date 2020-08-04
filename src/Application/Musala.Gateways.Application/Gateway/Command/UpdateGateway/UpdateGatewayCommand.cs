using MediatR;
using Musala.Gateways.Core.Responses;
using Musala.Gateways.Domain.Models;

namespace Musala.Gateways.Application.Gateway.Command.UpdateGateway
{
    public class UpdateGatewayCommand:IRequest<ApiResponse>
    {
        public long Id{get; set;}
        public GatewayModel Gateway{get; set;}
    }
}