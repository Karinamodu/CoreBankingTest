using AutoMapper;
using CoreBanking.Application.Customers.Commands.CreateCustomer;
using CoreBanking.Application.Customers.Queries.GetCustomerDetails;
using CoreBanking.Core.Entities;

namespace CoreBanking.Application.Common.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CreateCustomerCommand, Customer>();

            CreateMap<Customer, CustomerDetailsDto>();
        }
    }
}
