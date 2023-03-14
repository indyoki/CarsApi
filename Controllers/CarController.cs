using CarsApi.Models;
using CarsApi.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace CarsApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : Controller
    {
        private ICarService _carService;
        private readonly ILogger<CarController> _logger;
        public CarController(ICarService carService, ILogger<CarController> logger)
        {
            _carService = carService;
            _logger = logger;
        }

        [HttpGet("{page?}")]
        public async Task<ActionResult<CarResponse>> Get(int page = 1)
        {
            try
            {
                var result = await _carService.GetCars(page);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An exception occured retrieving cars with message: {ex.Message}");
                throw;
            }
        }

        [HttpGet("filter/{filterString}/{page?}")]
        public async Task<ActionResult<CarResponse>> GetCarsByFilter(string filterString, int page = 1)
        {
            try
            {
                var results = await _carService.GetCarsByFilter(filterString, page);
                
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An exception occured retrieving cars with text: {filterString}. With message: {ex.Message}");
                throw;
            }
        }
        [HttpPost]
        public async Task<ActionResult<int>> AddCar([FromBody] Car newCar)
        {
            try
            {
                var carId = await _carService.AddCar(newCar);
                return Ok(carId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An exception occured inserting new car with message: {ex.Message}");
                throw;
            }
        }
        [HttpPut]
        public async Task<ActionResult> UpdateCarDetails([FromBody] UpdateRequest car)
        {
            try
            {
                var results = await _carService.UpdateCarDetails(car);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An exception occured updating car Id: {car.Id}, with message: {ex.Message}");
                throw;
            }
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteCarById(int Id)
        {
            try
            {
                var result = await _carService.RemoveCarById(Id);
                if (result)
                    return Ok($"Car with Id: {Id} has been removed.");

                return NotFound($"Car with Id: {Id} does not exist.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occured while attempting to delete car with Id: {Id}, with message: {ex.Message}");
                throw;
            }
        }
    }
}
