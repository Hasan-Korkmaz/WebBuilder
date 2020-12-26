using System;
using System.Collections.Generic;
using System.Text;
using static WebBuilder.Core.Util.Enums;

namespace WebBuilder.Core.Model.Result
{
   public interface IResult<ReturnType>
    {
         Status Status { get; set; }
         ReturnType Data { get; set; }
         string Message { get; set; }

    }
}
