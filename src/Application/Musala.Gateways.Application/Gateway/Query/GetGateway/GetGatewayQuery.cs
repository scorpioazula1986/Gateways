using MediatR;
using Musala.Gateways.Core.Responses;

namespace Musala.Gateways.Application.Gateway.Query.GetGateway
{
    public class GetGatewayQuery:IRequest<ApiResponse>
    {
        public long Id { get; set; }
    }
}