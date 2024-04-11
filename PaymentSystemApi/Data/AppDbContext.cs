using Microsoft.EntityFrameworkCore;
using PaymentSystemApi.Models;

namespace PaymentSystemApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Merchant> Merchants { get; set; }  
        public DbSet<Customer> Customers { get; set; }  
    }
}
