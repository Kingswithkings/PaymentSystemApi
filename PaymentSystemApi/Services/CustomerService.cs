using AutoMapper;
using PaymentSystemApi.DTOs;
using PaymentSystemApi.Interfaces.IBaseRepository;
using PaymentSystemApi.Interfaces.IServices;
using PaymentSystemApi.Models;
using PaymentSystemApi.Repository;
using System.Runtime.CompilerServices;
using static PaymentSystemApi.Interfaces.IBaseRepository.IBaseRepository;

namespace PaymentSystemApi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IBaseRespository<Customer> _customerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CustomerService> _logger;

        public async Task<CustomerDTO> GetCustomerByIdAsync(int customerId)
        {
            var customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer == null)
            {
                _logger.LogWarning($"customer with ID {customerId} not found.");
                return null;
            }
            return _mapper.Map<CustomerDTO>(customer);
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllCustomerAsync()
        {
            var customers = await _customerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CustomerDTO>>(customers);
        }

        public async Task<bool> AddCustomerAsync(CustomerDTO customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            if (customer == null)
            {
                return false;

            }
            var Customer = new Customer
            {
                NIN = customerDTO.NIN,
                FirstName = customerDTO.FirstName,
                SurName = customerDTO.SurName,
                PhoneNumber = customerDTO.PhoneNumber,
                DateOfBirth = customerDTO.DateOfBirth,
                TransactionHistory = customerDTO.TransactionHistory

            };
            await _customerRepository.AddAsync(customer);

            return true;
        }

        public async Task UpdateCustomerAsync(int customerId, CustomerDTO customer)
        {
            var existingCustomer = await _customerRepository.GetByIdAsync(customerId);
            if (existingCustomer == null)
            {
                _logger.LogWarning($"customer with ID {customerId} not found.");
                return;
            }
            _mapper.Map(customer, existingCustomer);
            await _customerRepository.UpdateAsync(existingCustomer);
        }
        public async Task DeleteCustomerAsync(int customerId)
        {
            var customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer == null)
            {
                _logger.LogWarning($"customer with ID {customerId} not found.");
                return;
            }

            await _customerRepository.DeleteAsync(customer);
        }
    }
}
