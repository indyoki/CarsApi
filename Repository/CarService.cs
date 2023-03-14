using CarsApi.Models;
using CarsApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarsApi.Repository
{
    public class CarService : ICarService
    {
        private CarsDbContext _context;
        public CarService(CarsDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddCar(Car car)
        {
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
            return car.Id;
        }
        public async Task<CarResponse> GetCars(int page)
        {
            var perPage = 5.0;
            var pageCount = (int)Math.Ceiling(_context.Cars.Count() / perPage);
            var cars = await _context.Cars
                .Skip((page - 1) * (int)perPage)
                .Take((int)perPage).ToListAsync();
            return new CarResponse { cars = cars, page_number = page, per_page = (int)perPage, number_of_pages = pageCount };
        }

        public async Task<CarResponse> GetCarsByFilter(string filterString, int page)
        {
            filterString = filterString.ToLower();
            var cars = _context.Cars.Where(x => x.make.ToLower() == filterString
            || x.model.ToLower() == filterString
            || x.color.ToLower() == filterString);
            
            if(!cars.Any())
                return new CarResponse { cars = new List<Car>() };

            var perPage = 3.0;
            var pageCount = (int)Math.Ceiling(cars.Count() / perPage);
            cars = cars.Skip((page - 1) * (int)perPage).Take((int)perPage);
            return new CarResponse { cars = await cars.ToListAsync(), page_number = page, per_page = (int)perPage, number_of_pages = pageCount };
        }
        public async Task<bool> UpdateCarDetails(UpdateRequest car)
        {
            var toUpdate = await _context.Cars.FirstOrDefaultAsync(x => x.Id == car.Id);
            if (toUpdate == null)
                return false;

            toUpdate.price = car.price > 0 ? car.price : toUpdate.price;
            toUpdate.color = car.color ?? toUpdate.color;

            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> RemoveCarById(int Id)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(x => x.Id == Id);
            if (car == null)
                return false;

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
