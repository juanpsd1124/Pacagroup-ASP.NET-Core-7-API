
using AutoMapper;
using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Application.DTO;

namespace Pacagroup.Ecommerce.Transversal.Mapper
{
    public class MappingsProfile : Profile
    {
     
        public MappingsProfile() {
            
            CreateMap<Customers, CustomersDTO>().ReverseMap();
        }
    }
}