using AutoMapper;
using BookingSystemBackend.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Models.Mappings
{
    public class StationMapper : Profile
    {
        public StationMapper()
        {
            CreateMap<Station, StationDTO>()
                .ForMember(dest => dest.ArriveTime, opt => opt.MapFrom(source => source.ArriveTime.ToString()))
                .ForMember(dest => dest.DepartureTime, opt => opt.MapFrom(source => source.DepartureTime.ToString()))
                .ReverseMap()
                .ForPath(source => source.ArriveTime, opt => opt.MapFrom(dest => TimeSpan.Parse(dest.ArriveTime)))
                .ForPath(source => source.DepartureTime, opt => opt.MapFrom(dest => TimeSpan.Parse(dest.DepartureTime)));
        }
    }
}
