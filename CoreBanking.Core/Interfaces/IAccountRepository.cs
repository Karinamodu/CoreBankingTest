using CoreBanking.Core.Entities;
using CoreBanking.Core.ValueObjects;

namespace CoreBanking.Core.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account?> GetByIdAsync(AccountId accountId, CancellationToken cancellationToken);
        Task<List<Account>> GetAllAsync(CancellationToken cancellation);
        Task<Account?> GetByAccountNumberAsync(AccountNumber accountNumber);
        Task<IEnumerable<Account>> GetByCustomerIdAsync(CustomerId customerId, CancellationToken cancellationToken);
        Task AddAsync(Account account);
        Task UpdateAsync(Account account, CancellationToken cancellationToken);
        Task<bool> AccountNumberExistsAsync(AccountNumber accountNumber);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);


        // NEW METHODS FOR BACKGROUND JOBS
        Task<List<Account>> GetInactiveAccountsSinceAsync(DateTime sinceDate, CancellationToken cancellationToken = default);
        Task<List<Account>> GetInterestBearingAccountsAsync(CancellationToken cancellationToken = default);
        Task<List<Account>> GetActiveAccountsAsync(CancellationToken cancellationToken = default);
        Task<List<Account>> GetAccountsByStatusAsync(string status, CancellationToken cancellationToken = default);
        Task<List<Account>> GetAccountsWithLowBalanceAsync(decimal minimumBalance, CancellationToken cancellationToken = default);
    }
}