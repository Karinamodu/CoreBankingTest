using CoreBanking.Application.Common.Models;
using CoreBanking.Application.Customers.Queries.GetCustomers;
using CoreBanking.Core.Interfaces;
using CoreBanking.Core.ValueObjects;
using MediatR;

namespace CoreBanking.Application.Customers.Queries.GetCustomerDetails
{
    public class GetCustomerDetailsQueryHandler : IRequestHandler<GetCustomerDetailsQuery, Result<CustomerDto>>
    {
        private readonly ICustomerRepository _customerRepository;
        public GetCustomerDetailsQueryHandler(ICustomerRepository customerRepository) { _customerRepository = customerRepository; }
        public async Task<Result<CustomerDto>> Handle(GetCustomerDetailsQuery request, CancellationToken cancellationToken)
        {
            CustomerId customerId = CustomerId.Create(request.CustomerId);
            var customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer == null) return Result<CustomerDto>.Failure("Customer not found");
            var dto = new CustomerDto
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                DateCreated = customer.DateCreated,
                IsActive = customer.IsActive
            };
            return Result<CustomerDto>.Success(dto);
        }
    }
}
