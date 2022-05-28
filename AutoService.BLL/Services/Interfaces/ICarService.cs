using AutoService.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.BLL.Services.Interfaces
{
    public interface ICarService
    {
        Task<string> AddAsync(CarDto entity);
        Task<string> DeleteAsync(int id);
        Task<string> RemoveFromDbAsync(int id);
        Task<string> UpdateAsync(CarDto entity);
    }
}
