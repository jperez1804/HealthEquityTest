using Newtonsoft.Json;
using HealthEquity.Test.Domain.Services.Api;
using System.Net.Http;
using System.Text;
using System.Runtime.Serialization;
using HealthEquity.Test.Common.Exceptions;
using Microsoft.AspNetCore.Http;

namespace HealthEquity.Test.Services.Api.Exceptions
{
    [Serializable]
    public class ApiResultException : ProgramException
    {
        public override int? StatusCode { get; set; }
        public string Details { get; set; }
        public ApiResultException(string error, int statusCode = -1,  Exception ex = null)
            : base(string.Format("HealthEquity API Error: {0}", error), ex, statusCode)
        {
            Details = error;
        }
    
    }
}