using CoreBanking.Core.Entities;
using CoreBanking.Core.ValueObjects;

namespace CoreBanking.Core.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetByIdAsync(CustomerId customerId);
        Task<Customer?> GetByEmailAsync(string email);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task<bool> ExistsAsync(CustomerId customerId);
    }
}