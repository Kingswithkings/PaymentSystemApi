using Microsoft.EntityFrameworkCore;
using PaymentSystemApi.Data;
using PaymentSystemApi.Interfaces.IBaseRepository;
using PaymentSystemApi.Models;
using static PaymentSystemApi.Interfaces.IBaseRepository.IBaseRepository;

namespace PaymentSystemApi.Repository
{
    public class CustomerRepository : IBaseRespository<Customer>
    {
        private readonly AppDbContext _dbContext;

        public CustomerRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _dbContext.Customers.FindAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _dbContext.Customers.ToListAsync();
        }

        public async Task AddAsync(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            await SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
            _dbContext.Entry(customer).State = EntityState.Modified;
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(Customer customer)
        {
            _dbContext.Customers.Remove(customer);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}