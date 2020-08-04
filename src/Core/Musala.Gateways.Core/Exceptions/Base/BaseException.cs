using System;
using System.Net;

namespace Musala.Gateways.Core.Exceptions.Base
{
    public class BaseException:Exception
    {
        public string Recurso { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public string Mensaje { get; set; }

        public BaseException(string recurso, HttpStatusCode httpStatusCode, string mensaje = "")
        {
            Recurso = recurso;
            HttpStatusCode = httpStatusCode;
            Mensaje = mensaje;
        }

    }
}