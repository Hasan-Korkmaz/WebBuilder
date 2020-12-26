using System;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.AspNetCore.Mvc;


namespace CustomMiddleware.M
{
    public class LanguageMiddleware
    {
        private readonly RequestDelegate _next;

        public LanguageMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            
            var request = httpContext.Request.Path.Value;
            var sessionKeys = httpContext.Session.Keys.ToList();
           
            if (!String.IsNullOrEmpty(httpContext.Session.GetString("Language")))
            {
                httpContext.Session.SetString("Language", "TR");
            }

            var url = httpContext.Request.Path.Value;
            if (url=="/")
            {

            }
            return _next(httpContext);
        }
    }
}
