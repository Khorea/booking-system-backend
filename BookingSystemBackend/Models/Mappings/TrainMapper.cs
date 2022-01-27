using AutoMapper;
using BookingSystemBackend.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Models.Mappings
{
    public class TrainMapper : Profile
    {
        public TrainMapper()
        {
            // Does not work
            CreateMap<Train, TrainDTO>()
                .ForMember(dest => dest.TrainType, opt => opt.MapFrom(source => source.TrainType))
                .ForMember(dest => dest.Stations, opt => opt.MapFrom(source => source.Stations))
                .ForMember(dest => dest.TrainLayout, opt => opt.MapFrom(source => source.Cars));
            CreateMap<Train, TrainDetails>()
                .ForMember(dest => dest.TrainType, opt => opt.MapFrom(source => source.TrainType))
                .ForMember(dest => dest.DepartureTime, opt => opt.MapFrom(source => source.Stations.OrderBy(x => x.OrderNumber).First().DepartureTime))
                .ForMember(dest => dest.ArrivalTime, opt => opt.MapFrom(source => source.Stations.OrderBy(x => x.OrderNumber).Last().ArriveTime))
                .ForMember(dest => dest.DepartureStation, opt => opt.MapFrom(source => source.Stations.OrderBy(x => x.OrderNumber).First().Location))
                .ForMember(dest => dest.ArrivalStation, opt => opt.MapFrom(source => source.Stations.OrderBy(x => x.OrderNumber).Last().Location))
                .ForMember(dest => dest.TotalDuration, opt => opt.MapFrom(source => (source.Stations.OrderBy(x => x.OrderNumber).Last().ArriveTime - source.Stations.OrderBy(x => x.OrderNumber).First().DepartureTime).ToString()))
                .ForMember(dest => dest.StationCount, opt => opt.MapFrom(source => source.Stations.Count));
        }

        
    }
}
