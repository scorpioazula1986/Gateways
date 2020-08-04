using System.Net;
using Musala.Gateways.Core.Exceptions.Base;

namespace Musala.Gateways.Core.Exceptions.Common
{ /**
 * @Author:Enmanuel Lara Marianos
 * Esta excepcion se lanza cuando el recurso tiene recursos asociados y no se puede eliminar
 */
    public class DependantChildException : BaseException
    {
        public string Child{get; set;}
        public DependantChildException(string recurso, string child) : base(recurso, HttpStatusCode.Conflict, "")
        {
            Child=child;
            

        }
    }
}