using Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebBuilder.Business.Concrete;
using WebBuilder.Core.Model.Result;

namespace WebBuilder.Middleware.Middlewares
{
    public class BackofisLanguageMiddleware
    {
      
            private readonly RequestDelegate _next;
            UiDataService service;
            IResult<List<Language>> val;
            public BackofisLanguageMiddleware(RequestDelegate next)
            {
                _next = next;
            }
            public async Task Invoke(HttpContext httpContext, UiDataService service)
            {

                this.service = service;
                val = await service.LanguageService.GetList();
                var url = httpContext.Request.Path.Value;
                string languageShortName;


                languageShortName = null;
                //Eğer Dil Seçimi yapılmamış ise dili güncelle ve url oluştur
                httpContext.Session.Remove("Language");
            service.LanguageConfigure = languageShortName;

            await _next(httpContext);

        }
          

        
    }
}
