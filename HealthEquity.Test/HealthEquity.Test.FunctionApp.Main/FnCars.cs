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
using System.Collections.Generic;
using HealthEquity.Test.Common.Exceptions;
using HealthEquity.Test.Services.Api.Exceptions;

namespace HealthEquity.Test.FunctionApp.Main
{
    [ApiExplorerSettings(GroupName = "Cars")]
    public class FnCars
    {
        private readonly ICarService _carService;
        public FnCars(ICarService carService)
        {
            _carService = carService;

        }


        [FunctionName(nameof(GetCar))]
        [ProducesResponseType(typeof(List<Car>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetCar(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "car/{id}")] HttpRequest req, int id,ILogger log)
        {

            try
            {
                Car car = await _carService.GetCar(id);
                return new OkObjectResult(car);
            }
            catch (Exception ex)
            {
                return CatchException(ex);
            }


        }


        [FunctionName(nameof(GetCars))]
        [ProducesResponseType(typeof(List<Car>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetCars(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "carList")] HttpRequest req, ILogger log)
        {

            try
            {
                List<Car> carList = await _carService.GetCars();
                return new OkObjectResult(carList);
            }
            catch (Exception ex)
            {
                return CatchException(ex);
            }


        }

        [FunctionName(nameof(AddCars))]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AddCars(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "car")] HttpRequest req, ILogger log)
        {
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                var newCar = JsonConvert.DeserializeObject<Car>(requestBody);

                return new ObjectResult(await _carService.AddCar(newCar));
            }
            catch (Exception ex)
            {
                return CatchException(ex);
            }
        }


        [FunctionName(nameof(UpdateCars))]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ExceptionResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateCars(
        [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "car/{id}")] HttpRequest req, int id, ILogger log)
        {
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                var newCar = JsonConvert.DeserializeObject<Car>(requestBody);

                return new ObjectResult(await _carService.UpdateCar(newCar, id));
            }
            catch (Exception ex)
            {
                return CatchException(ex);
            }
        }


        private IActionResult CatchException(Exception ex)
        {
            ExceptionResponse exResponse = new ExceptionResponse()
            {
                Message = ex.Message,
                Details = ex is ApiResultException ? (ex as ApiResultException).Details : ex.Message
            };

            return new ObjectResult(exResponse)
            {
                StatusCode = ex is ApiResultException ? ((ex as ApiResultException).StatusCode != -1 ? (ex as ApiResultException).StatusCode : StatusCodes.Status400BadRequest)
                : StatusCodes.Status500InternalServerError
            };
        }


    }
}
