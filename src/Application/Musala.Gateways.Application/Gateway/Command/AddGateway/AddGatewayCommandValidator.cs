using FluentValidation;
using Musala.Gateways.Domain.Models;

namespace Musala.Gateways.Application.Gateway.Command.AddGateway
{
    public class AddGatewayCommandValidator : AbstractValidator<GatewayModel>
    {
        public AddGatewayCommandValidator()
        {
            RuleFor(e=>e.SerialNumber).Length(50).NotEmpty().NotNull();
            RuleFor(e=>e.Name).Length(50).NotEmpty().NotNull();
            RuleFor(e=>e.Ipv4).NotEmpty().NotNull().Length(20);
        }
    }
}