using PaymentSystemApi.DTOs;

namespace PaymentSystemApi.Interfaces.IServices
{
    public interface ICustomerService
    {
        Task<CustomerDTO> GetCustomerByIdAsync(int customerId);
        Task<IEnumerable<CustomerDTO>> GetAllCustomerAsync();
        Task<bool> AddCustomerAsync(CustomerDTO customerDTO);
        Task UpdateCustomerAsync(int customerId, CustomerDTO customerDTO);
        Task DeleteCustomerAsync(int customerId);

    }
}
