using HealthEquity.Test.Domain.Services.Api;
using HealthEquity.Test.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthEquity.Test.Domain.Services
{
    public interface ICarService
    {

        Task<Car> GetCar(int id);

        Task<List<Car>> GetCars();

        Task<ApiResult<dynamic>> AddCar(Car car);

        Task<ApiResult<dynamic>> UpdateCar(Car car, int id);


    }
}
