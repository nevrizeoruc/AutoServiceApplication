using AutoService.Core.DTOs;
using AutoService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.BLL.Services.Interfaces
{
    public interface ICustomerRepository
    {
        Task<string> AddAsync(CustomerDto entity);
        Task<string> DeleteAsync(int id);
        Task<string> RemoveFromDbAsync(int id);
        Task<string> UpdateAsync(CustomerDto entity);
        Task AddAsync(Customer category);
    }
}
