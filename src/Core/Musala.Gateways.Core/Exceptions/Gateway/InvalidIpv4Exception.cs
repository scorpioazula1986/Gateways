using System.Net;
using Musala.Gateways.Core.Exceptions.Base;

namespace Musala.Gateways.Core.Exceptions.Gateway
{
    public class InvalidIpv4Exception:BaseException
    {
        public InvalidIpv4Exception() : base(string.Empty, HttpStatusCode.BadRequest, string.Empty)
        {
        }
    }
}