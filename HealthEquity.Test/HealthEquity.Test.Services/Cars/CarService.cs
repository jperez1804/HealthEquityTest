using HealthEquity.Test.Domain.Services;
using HealthEquity.Test.Domain.Services.Api;
using HealthEquity.Test.Domain.ValueObjects;
using HealthEquity.Test.Services.Api.Exceptions;
using Microsoft.AspNetCore.Http;

namespace HealthEquity.Test.Services.Cars
{
    public class CarService : ICarService
    {
        private readonly List<Car> _cars;

        public CarService()
        {
            _cars = new List<Car>()
            {
                new Car { Id = 1, Make = "Audi", Model = "R8", Year = 2018, Doors = 2, Color = "Red", Price = 79995 },
                new Car { Id = 2, Make = "Tesla", Model = "3", Year = 2018, Doors = 4, Color = "Black", Price = 54995 },
                new Car { Id = 3, Make = "Porsche", Model = "911 991", Year = 2020, Doors = 2, Color = "White", Price = 155000 },
                new Car { Id = 4, Make = "Mercedes-Benz", Model = "GLE 63S", Year = 2021, Doors = 5, Color = "Blue", Price = 83995 },
                new Car { Id = 5, Make = "BMW", Model = "X6 M", Year = 2020, Doors = 5, Color = "Silver", Price = 62995 },
            };
        }

        public async Task<Car> GetCar(int id)
        {
            ApiResult<dynamic> result = new ApiResult<dynamic>();
            Car car = null;
            try
            {
                car = _cars.SingleOrDefault(x => x.Id == id);
                if (car == null)
                {
                    throw new ApiResultException($"{typeof(Car)} Not Found", StatusCodes.Status404NotFound);
                }

            }
            catch (ApiResultException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                result.IsSuccessStatusCode = false;
                throw new ApiResultException(ex.Message);
            }


            return car;
        }

        public async Task<List<Car>> GetCars()
        {
            ApiResult<dynamic> result = new ApiResult<dynamic>();
            try
            {

            }
            catch (Exception ex)
            {
                result.IsSuccessStatusCode = false;
                throw new ApiResultException(ex.Message);
            }


            return _cars;
        }

        public async Task<ApiResult<dynamic>> AddCar(Car car)
        {
            ApiResult<dynamic> result = new ApiResult<dynamic>();
            try
            {
                car.Id = _cars.OrderBy(x => x.Id).Last().Id + 1;
                _cars.Add(car);
                int test = Convert.ToInt32("k");
                result.IsSuccessStatusCode = true;
            }
            catch (Exception ex)
            {
                result.IsSuccessStatusCode = false;

                throw new ApiResultException(ex.Message);

            }

            return result;

        }

        public async Task<ApiResult<dynamic>> UpdateCar(Car car, int id)
        {
            ApiResult<dynamic> result = new ApiResult<dynamic>();
            try
            {
                var updatedCar = _cars.SingleOrDefault(x => x.Id == id);


                if (updatedCar == null)
                {
                    throw new ApiResultException($"{typeof(Car)} Not Found", StatusCodes.Status404NotFound);
                }

                updatedCar.Year = car.Year;
                updatedCar.Make = car.Make;
                updatedCar.Model = car.Model;
                updatedCar.Price = car.Price;
                updatedCar.Color = car.Color;
                updatedCar.Doors = car.Doors;

                result.IsSuccessStatusCode = true;
            }
            catch (ApiResultException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                result.IsSuccessStatusCode = false;

                throw new ApiResultException(ex.Message);

            }

            return result;
        }


    }
}