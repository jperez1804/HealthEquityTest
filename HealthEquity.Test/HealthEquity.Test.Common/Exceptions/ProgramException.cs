using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HealthEquity.Test.Common.Exceptions
{
    [Serializable]
    public class ProgramException : Exception
    {
        public ProgramException()
        {
            StatusCode = StatusCodes.Status400BadRequest;
        }

        public ProgramException(string message, Exception innerException = null, int statusCode = -1) : base(message, innerException)
        {
            StatusCode = statusCode == -1 ? StatusCodes.Status400BadRequest : statusCode;
        }

        public virtual int? StatusCode { get; set; }

    }
}
