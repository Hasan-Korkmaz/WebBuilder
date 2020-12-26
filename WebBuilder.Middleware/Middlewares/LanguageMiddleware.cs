 using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions;
using Microsoft.AspNetCore.Session;
using WebBuilder.Business.Abstract.DataServices;
using Entity;
using WebBuilder.Core.Model.Result;
using WebBuilder.Business.Concrete;

namespace WebBuilder.Middleware.Middlewares
{
    public class LanguageMiddleware
    {
        private readonly RequestDelegate _next;
        UiDataService service;
        IResult<List<Language>> val;
        public LanguageMiddleware(RequestDelegate next )
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext, UiDataService service)
        {
            
            this.service = service;
            val = await service.LanguageService.GetList();
            var url = httpContext.Request.Path.Value;
            string languageShortName;
           
            if (String.IsNullOrEmpty(httpContext.Session.GetString("Language")))
            {
                languageShortName = "tr-TR";
                //Eğer Dil Seçimi yapılmamış ise dili güncelle ve url oluştur
                httpContext.Session.SetString("Language", languageShortName);
            }
            else
            {
                languageShortName= httpContext.Session.GetString("Language");
            }
            service.LanguageConfigure = languageShortName;
            await _next(httpContext);
        }

    }
}
