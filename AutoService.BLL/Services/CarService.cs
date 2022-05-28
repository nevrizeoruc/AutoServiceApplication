using AutoService.BLL.Services.Interfaces;
using AutoService.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.BLL.Services
{
    public class CarService : ICarService
    {
        public Task<string> AddAsync(CarDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> RemoveFromDbAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateAsync(CarDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
