using System.Net;
using Musala.Gateways.Core.Exceptions.Base;

/**
 * @Author:Enmanuel Lara Marianos
 * Esta excepcion se lanza cuando el recurso solicitado no es encuentra
 */
namespace Musala.Gateways.Core.Exceptions.Common
{
     public class NotFoundException:BaseException
    {
       

        public NotFoundException(string recurso) : base(recurso, HttpStatusCode.NotFound, "")
        {
            
        }
    }
}