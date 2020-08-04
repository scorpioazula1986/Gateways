using System.Net;
using Musala.Gateways.Core.Exceptions.Base;

namespace Musala.Gateways.Core.Exceptions.Common
{ /**
 * @Author:Enmanuel Lara Marianos
 * Esta excepcion se lanza cuando el recurso debe ser unico
 */
    public class UniqueException : BaseException
    {
        public UniqueException(string recurso) : base(recurso, HttpStatusCode.Conflict, "")
        {
        }
    }
}