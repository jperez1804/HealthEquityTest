using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthEquity.Test.Domain.Services.Api
{
    public class ApiResult<T>
    {
        public bool IsSuccessStatusCode { get; set; }                        

        public T Content { get; set; }
    }
}
