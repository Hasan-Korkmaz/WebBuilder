using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using WebBuilder.Middleware.Middlewares;
using System.Diagnostics;

namespace WebBuilder.Middleware
{
    public static class WebBuilderMiddlewaresExtension
    {
        public static IApplicationBuilder UseWebBuilderMiddlewares(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<LanguageMiddleware>();
            return builder;
        }
    }
}
