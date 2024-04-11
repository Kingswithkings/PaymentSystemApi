using AutoMapper;
using PaymentSystemApi.DTOs;
using PaymentSystemApi.Models;

namespace PaymentSystemApi.Profiles.Automappings
{
    public class PaymentSystemMappings : Profile
    {
        public PaymentSystemMappings() 
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();

            CreateMap<Merchant, MerchantDTO>();
            CreateMap<MerchantDTO, Merchant>();
        }
    }
}
