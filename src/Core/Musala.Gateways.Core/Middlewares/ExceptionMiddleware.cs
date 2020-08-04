using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Musala.Gateways.Core.Exceptions.Base;
using Musala.Gateways.Core.Exceptions.Common;
using Musala.Gateways.Core.Exceptions.Gateway;
using Musala.Gateways.Core.Responses;
using Newtonsoft.Json;

namespace Musala.Gateways.Core.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        
        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch(BaseException ex){
                await HandleApiExceptionAsync(context,ex);
                
            }
           
           
        }
        private  Task HandleApiExceptionAsync(HttpContext context, BaseException exception)
        {
             var result = new ErrorResponse();
             switch (exception)
             {
                case NotFoundException notFoundException:
                {
                    result.Message = "The " + notFoundException.Recurso + " was not found";
                    break;
                }
               
                case InvalidIpv4Exception invalidIpv4Exception:
                {
                    result.Message = "The ip is not valid";

                    break;
                }
                case FullGatewayException fullGatewayException:
                {
                    result.Message = "The gateway cannot have more devices";

                    break;
                }
                
                    
               

             }


            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) exception.HttpStatusCode;
            return context.Response.WriteAsync(
                JsonConvert.SerializeObject(result));
        }



    }

}