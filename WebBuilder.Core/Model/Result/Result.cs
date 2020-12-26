using System;
using System.Collections.Generic;
using System.Text;
using static WebBuilder.Core.Util.Enums;

namespace WebBuilder.Core.Model.Result
{
   public class Result<ReturnType>:IResult<ReturnType>
    {
        public Status Status{ get; set; }
        public ReturnType Data { get; set; }
        public string Message { get; set; }
    }
}
