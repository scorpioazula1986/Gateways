using FluentValidation;
using Musala.Gateways.Domain.Models;

namespace Musala.Gateways.Application.Gateway.Command.UpdateGateway

{
    public class UpdateGatewayCommandValidator : AbstractValidator<GatewayModel>
    {
        public UpdateGatewayCommandValidator()
        {
            RuleFor(e=>e.SerialNumber).Length(50).NotEmpty().NotNull();
            RuleFor(e=>e.Name).Length(50).NotEmpty().NotNull();
            RuleFor(e=>e.Ipv4).NotEmpty().NotNull().Length(20);
        }
    }
}