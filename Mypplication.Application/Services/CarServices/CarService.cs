using Microsoft.EntityFrameworkCore;
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
                return "Qo'shilmadi Error mavjud";
            }
        }

        public async Task<string> DeleteCar(int id)
        {
            try
            {
                var model = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
                if (model is not null)
                {
                    _context.Cars.Remove(model);
                    await _context.SaveChangesAsync();
                    return "O'chirildi";
                }
                else
                {
                    return "Toplimadi";
                }
            }
            catch
            {
                return "O'chirilmadi Error mavjud";
            }
        }

        public async Task<IEnumerable<Car>> GetAllCars()
        {
            try
            {
                return await _context.Cars.ToListAsync();
            }
            catch
            {
                return Enumerable.Empty<Car>();
            }
        }

        public async Task<Car> GetCarById(int id)
        {
            try
            {
                var x = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
                if (x is not null)
                {
                    return x;
                }
                return new Car() { Brand = "Null",Model = "Null" };
            }
            catch
            {
                return new Car() { Brand = "Null", Model = "Null" };
            }
        }


        public async Task<string> UpdateCar(int id, CarDTO cr)
        {
            try
            {
                var x = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
                if (x is not null)
                {
                    x.Model = cr.Model;
                    x.Brand = cr.Brand;
                    x.Price = cr.Price;
                    x.Description = cr.Description;
                    _context.SaveChanges();
                }
                return "Topilmadi";
            }
            catch
            {
                return "Error topildi";
            }
        }
    }
}
