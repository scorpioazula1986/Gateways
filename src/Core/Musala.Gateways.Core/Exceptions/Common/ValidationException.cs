using System.Collections.Generic;
using System.Net;
using Musala.Gateways.Core.Exceptions.Base;

namespace Musala.Gateways.Core.Exceptions.Common
{
    /**
 * @Author:Enmanuel Lara Marianos
 * Esta excepcion se lanza cuando hay errores de validacion
 */
    public class ValidationException:BaseException
    {
        public IDictionary<string, string[]> Failures { get; }
        public ValidationException(string recurso) : base(recurso,HttpStatusCode.BadRequest,"Una o más validaciones han fallado")
        {
            Failures = new Dictionary<string, string[]>();
        }
    }
}