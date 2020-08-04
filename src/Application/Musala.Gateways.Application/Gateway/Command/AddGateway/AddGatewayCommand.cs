using MediatR;
using Musala.Gateways.Core.Responses;
using Musala.Gateways.Domain.Models;

namespace Musala.Gateways.Application.Gateway.Command.AddGateway
{
    public class AddGatewayCommand:IRequest<ApiResponse>
    {
        public GatewayModel Gateway{get; set;}
    }
}