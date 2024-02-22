using MyApplication.Domain.Entities.DTOs;
using MyApplication.Domain.Entities.Models;
using MyApplication.Infrastruct.Persistance;

namespace Mypplication.Application.Services.CarServices
{

    internal class CarService : ICarService
    {
        private readonly ApplicationDbContext _context;
        public CarService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> CreateCar(CarDTO cr)
        {
            try
            {
                var model = new Car()
                {
                    Model = cr.Model,
                    Brand = cr.Brand,
                    Description = cr.Description,
                    CarCondition = cr.CarCondition,
                    Price = cr.Price
                };
                await _context.Cars.AddAsync(model);
                await _context.SaveChangesAsync();
                return "Qo'shildi";
            }
            catch
            {
                return "Qo'shilmadi";
            }
        }

        public Task<string> DeleteCar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Car>> GetAllCars()
        {
            throw new NotImplementedException();
        }

        public Task<Car> GetCarById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateCar(int id, CarDTO cr)
        {
            throw new NotImplementedException();
        }
    }
}
