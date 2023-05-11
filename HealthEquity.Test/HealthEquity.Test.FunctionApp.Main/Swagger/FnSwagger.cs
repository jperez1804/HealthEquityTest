using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using AzureFunctions.Extensions.Swashbuckle.Attribute;
using System.Net;
using HealthEquity.Test.Domain.Services;
using System.Xml.Linq;
using HealthEquity.Test.Domain.ValueObjects;
using AzureFunctions.Extensions.Swashbuckle;
using System.Net.Http;

namespace HealthEquity.Test.FunctionApp.Main.Swagger
{




    public static class FnSwagger
    {
        [SwaggerIgnore]
        [FunctionName(nameof(Swagger))]
        public static Task<HttpResponseMessage> Swagger(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "swagger/json")]
            HttpRequestMessage req,
            [SwashBuckleClient] ISwashBuckleClient swashBuckleClient)
        {
            return Task.FromResult(swashBuckleClient.CreateSwaggerJsonDocumentResponse(req));
        }

        [SwaggerIgnore]
        [FunctionName(nameof(SwaggerUi))]
        public static Task<HttpResponseMessage> SwaggerUi(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "swagger/ui")]
            HttpRequestMessage req,
            [SwashBuckleClient] ISwashBuckleClient swashBuckleClient)
        {
            return Task.FromResult(swashBuckleClient.CreateSwaggerUIResponse(req, "swagger/json"));
        }
    }
}
