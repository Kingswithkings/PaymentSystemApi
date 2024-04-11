using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentSystemApi.DTOs;
using PaymentSystemApi.Interfaces.IServices;
using PaymentSystemApi.Models;
using System.Security.Cryptography.X509Certificates;

namespace PaymentSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<CustomerController> _logger; 
        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }
        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerById(int customerId)
        {
            try
            {
                var customer = await _customerService.GetCustomerByIdAsync(customerId);
                if (customer == null)
                    return NotFound($"Customer with ID {customerId} not found.");
                return Ok(customer);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting customer with ID {customerId}; {ex.Message}");
                return StatusCode(500, "internal Server Error");
            }
        }
            [HttpGet]
            public async Task<IActionResult> GetAllCustomersAsync()
            {
                try
                {
                    var customers = await _customerService.GetAllCustomerAsync();
                    return Ok(customers);
                }
                catch(Exception ex)
                {
                    _logger.LogError($"Error getting all customers: {ex.Message}");
                    return StatusCode(500, "Internal Server Error");
                }
            }
        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerDTO customerDTO)
        {
            try
            {
                if (customerDTO == null)
                    return BadRequest("Invalid customer data");

                await _customerService.AddCustomerAsync(customerDTO);
                return Ok("customer added sucessfully");
            }
            catch (Exception ex)
            {

                _logger.LogError($"Error adding customer: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpPut("{customerId}")]
        public async Task<IActionResult> UpdateCustomer(int customerId, [FromBody] CustomerDTO customerDTO)
        {
            try
            {
                await _customerService.UpdateCustomerAsync(customerId, customerDTO);
                return Ok("Customer updated sucessfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating customer with ID {customerId}: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomer(int customerId)
        {
            try
            {
                await _customerService.DeleteCustomerAsync(customerId);
                return Ok("Customer deleted sucessfully");
            }
            catch (Exception ex)
            {

                _logger.LogError($"Error deleting customer with ID {customerId}: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }


    }
}

