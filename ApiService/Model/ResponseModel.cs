using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Model
{
    public class ResponseModel
    {
        public string Message { get; set; }
        public int Status { get; set; }
        public object Response { get; set; }
    }
}
