using CoreBanking.Application.Common.Interfaces;
using CoreBanking.Application.Common.Models;
using CoreBanking.Application.Customers.Queries.GetCustomers;
using CoreBanking.Core.Interfaces;
using CoreBanking.Core.ValueObjects;
using MediatR;

namespace CoreBanking.Application.Customers.Queries.GetCustomerDetails
{

    public record GetCustomerDetailsQuery : IQuery<CustomerDto>
    {
        public Guid CustomerId { get; init; }
    }

    
}