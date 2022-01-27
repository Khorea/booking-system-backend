using AutoMapper;
using BookingSystemBackend.Models.DTOs;

namespace BookingSystemBackend.Models.Mappings
{
    public class PersonMapper : Profile
    {
        public PersonMapper()
        {
            CreateMap<Person, PersonDetails>()
                .ForMember(dest => dest.Username, source => source.MapFrom(source => source.Account.Username))
                .ForMember(dest => dest.Role, source => source.MapFrom(source => source.Account.Role))
                .ReverseMap()
                .ForPath(source => source.Account.Username, opt => opt.MapFrom(dest => dest.Username))
                .ForPath(source => source.Account.Role, opt => opt.MapFrom(dest => dest.Role));
        }
    }
}
