using CoreBanking.Core.Common;
using CoreBanking.Core.Events;
using CoreBanking.Core.ValueObjects;

namespace CoreBanking.Core.Entities
{
    public class Customer : ISoftDelete
    {
        public CustomerId CustomerId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Address { get; private set; }
        public DateOnly DateOfBirth { get; init; }
        public DateTime DateCreated { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime? DeletedAt { get; private set; }
        public string? DeletedBy { get; private set; }

        // Domain events collection
        private readonly List<DomainEvent> _domainEvents = new();
        public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        // Navigation property for accounts
        private readonly List<Account> _accounts = new();
        public IReadOnlyCollection<Account> Accounts => _accounts.AsReadOnly();

        private Customer() { } // EF Core needs this

        private Customer(string firstName, string lastName, string email, string phoneNumber
            , string address, DateOnly dateOfBirth
            )
        {
            CustomerId = CustomerId.Create();
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            DateOfBirth = dateOfBirth;
            DateCreated = DateTime.UtcNow;
            IsActive = true;
        }

        public static Customer Create(
            string firstName,
            string lastName,
            string email,
            string phoneNumber,
            string address,
            DateOnly dateOfBirth
            )
        {
            var customer = new Customer(
                firstName: firstName,
                lastName: lastName,
                email: email,
                phoneNumber: phoneNumber,
                address: address,
                dateOfBirth: dateOfBirth
                )
            {

            };

            //add domain event
            customer.AddDomainEvent(new CustomerCreatedEvent(
                firstName: customer.FirstName,
                lastName: customer.LastName,
                email: customer.Email,
                phoneNumber: customer.PhoneNumber,
                address: customer.Address,
                dateOfBirth: customer.DateOfBirth));

            return customer;
        }

        // Business methods
        public void UpdateContactInfo(string email, string phoneNumber)
        {
            if (!IsActive)
                throw new InvalidOperationException("Cannot update inactive customer");

            Email = email;
            PhoneNumber = phoneNumber;
        }

        public void Deactivate()
        {
            if (_accounts.Any(a => a.Balance.Amount > 0))
                throw new InvalidOperationException("Cannot deactivate customer with account balance");

            IsActive = false;
        }

        internal void AddAccount(Account account)
        {
            _accounts.Add(account);
        }

        public void AddDomainEvent(DomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void SoftDelete(string deletedBy)
        {
            if (Accounts.Any(a => a.Balance.Amount > 0))
                throw new InvalidOperationException("Cannot delete customer with account balance");

            IsDeleted = true;
            DeletedAt = DateTime.UtcNow;
            DeletedBy = deletedBy;
        }
    }
}