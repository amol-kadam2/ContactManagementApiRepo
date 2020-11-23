using System.Net;  
using System.Net.Http;  
using System.Web.Http.Filters;

namespace ContactManagementApi.Filters
{
    public class ContactExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("We are unable to process your request at the moment. please try again later."),  
                ReasonPhrase = "Internal Server Error.Please Contact your Administrator."
            };

            actionExecutedContext.Response = response;
        }
    }
}