using CoreBanking.Application.Common.Models;
using CoreBanking.Core.Entities;
using CoreBanking.Core.Interfaces;
using MediatR;

namespace CoreBanking.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Result<Guid>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerCommandHandler(
            ICustomerRepository customerRepository,
            IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            //check if customer alreasy exists with same email
            var existingCustomer = await _customerRepository.GetByEmailAsync(request.Email);
            if (existingCustomer != null)
            {
                return Result<Guid>.Failure("This customer email already has an account.");
            }
            //Create new customer entity
            var customer = Customer.Create(
                firstName: request.FirstName,
                lastName: request.LastName,
                email: request.Email,
                phoneNumber: request.PhoneNumber,
                address: request.Address,
                dateOfBirth: request.DateOfBirth
            );

            // Add to repository
            await _customerRepository.AddAsync(customer);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result<Guid>.Success(customer.CustomerId.Value);
        }
    }
}

