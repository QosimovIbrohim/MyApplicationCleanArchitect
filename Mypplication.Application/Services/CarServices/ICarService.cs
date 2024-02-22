using MyApplication.Domain.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mypplication.Application.Services.CarServices
{
    internal interface ICarService
    {
        public Task<string> CreateCar(CarDTO cr);
        public Task<string> UpdateCar(int id, CarDTO cr);



    }
}
