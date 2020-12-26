using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.FrontDataTypes
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public bool DataStatus { get; set; }
        public string Message{ get; set; }
        public object Data { get; set; }
    }
}
