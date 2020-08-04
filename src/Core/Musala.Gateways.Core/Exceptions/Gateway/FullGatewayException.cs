using System.Net;
using Musala.Gateways.Core.Exceptions.Base;

namespace Musala.Gateways.Core.Exceptions.Gateway
{
    public class FullGatewayException:BaseException
    {
        public FullGatewayException() : base(string.Empty, HttpStatusCode.Locked, string.Empty)
        {
        }
    }
}