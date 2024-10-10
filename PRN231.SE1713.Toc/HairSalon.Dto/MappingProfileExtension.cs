using AutoMapper;
using HairSalon.Core.Entities;
using HairSalon.Dto.Responses;

namespace HairSalon.Dto
{
    public class MappingProfileExtension : Profile
    {
        /// <summary>
        /// Mapping entities from core layer to DTO layer
        /// </summary>
        public MappingProfileExtension()
        {
            CreateMap<Customer, LoggedInUserModel>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => "CUSTOMER"));

            CreateMap<Employee, LoggedInUserModel>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));

            CreateMap<Service, HairServiceDto>().ReverseMap();
        }
    }
}
