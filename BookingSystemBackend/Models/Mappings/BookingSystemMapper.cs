using AutoMapper;
using BookingSystemBackend.Models.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace BookingSystemBackend.Models.Mappings
{
	public class BookingSystemMapper : Profile
	{
        public BookingSystemMapper()
        {
            CreateMap<Person, PersonDetails>()
                .ForMember(dest => dest.Username, source => source.MapFrom(source => source.Account.Username))
                .ForMember(dest => dest.Role, source => source.MapFrom(source => source.Account.Role))
                .ReverseMap()
                .ForPath(source => source.Account.Username, opt => opt.MapFrom(dest => dest.Username))
                .ForPath(source => source.Account.Role, opt => opt.MapFrom(dest => dest.Role));

            CreateMap<ICollection<Car>, TrainLayout>()
                .ForMember(dest => dest.FirstClass, opt => opt.MapFrom(source => source.ToList().FindAll(car => car.CarType.Equals("First Class")).Count))
                .ForMember(dest => dest.SecondClass, opt => opt.MapFrom(source => source.ToList().FindAll(car => car.CarType.Equals("Second Class")).Count))
                .ForMember(dest => dest.FirstClassSleeper, opt => opt.MapFrom(source => source.ToList().FindAll(car => car.CarType.Equals("First Class Sleeper")).Count))
                .ForMember(dest => dest.Couchette, opt => opt.MapFrom(source => source.ToList().FindAll(car => car.CarType.Equals("Couchette")).Count));

            CreateMap<Person, PersonDetails>()
                .ForMember(dest => dest.Username, source => source.MapFrom(source => source.Account.Username))
                .ForMember(dest => dest.Role, source => source.MapFrom(source => source.Account.Role))
                .ReverseMap()
                .ForPath(source => source.Account.Username, opt => opt.MapFrom(dest => dest.Username))
                .ForPath(source => source.Account.Role, opt => opt.MapFrom(dest => dest.Role));

            CreateMap<Station, StationDTO>();

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
