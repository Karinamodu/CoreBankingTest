using CoreBanking.Core.Common;
using CoreBanking.Core.Enums;
using CoreBanking.Core.ValueObjects;

namespace CoreBanking.Core.Events
{
    public record CustomerCreatedEvent : DomainEvent
    {
        public CustomerId CustomerId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string PhoneNumber { get; }
        public string Address { get; }
        public DateOnly DateOfBirth { get; }

        public CustomerCreatedEvent(
            string firstName,
            string lastName,
            string email,
            string phoneNumber,
            string address,
            DateOnly dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            DateOfBirth = dateOfBirth;
        }
    }
}
