using CarsApi.Models;

namespace CarsApi.Repository.Interfaces
{
    public interface ICarService
    {
        Task<int> AddCar(Car car);
        Task<CarResponse> GetCars(int page);
        Task<CarResponse> GetCarsByFilter(string filterString, int page);
        Task<bool> RemoveCarById(int Id);
        Task<bool> UpdateCarDetails(UpdateRequest car);
    }
}