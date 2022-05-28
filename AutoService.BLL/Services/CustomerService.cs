using AutoMapper;
using AutoService.BLL.Services.Interfaces;
using AutoService.Common.Utilities;
using AutoService.Core.DTOs;
using AutoService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<string> AddAsync(CustomerDto entity)
        {
            try
            {
                var category = _mapper.Map<Customer>(entity);
                await _customerRepository.AddAsync(category);
                return Messages.Added;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public Task<string> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> RemoveFromDbAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateAsync(CustomerDto entity)
        {
            throw new NotImplementedException();
        }
    }
    }
}
