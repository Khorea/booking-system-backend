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
            CreateMap<Connection, ConnectionDTO>()
                .ForMember(dest => dest.StartStationId, opt => opt.MapFrom(source => source.StartStationId))
                .ForMember(dest => dest.EndStationId, opt => opt.MapFrom(source => source.EndStationId))
                .ForMember(dest => dest.ArriveTime, opt => opt.MapFrom(source => source.ArriveTime))
                .ForMember(dest => dest.DepartureTime, opt => opt.MapFrom(source => source.DepartureTime))
                .ForMember(dest => dest.Distance, opt => opt.MapFrom(source => source.Distance))
                .ForMember(dest => dest.Line, opt => opt.MapFrom(source => source.Line))
                .ForMember(dest => dest.OrderNumber, opt => opt.MapFrom(source => source.OrderNumber))
                .ReverseMap()
                .ForPath(source => source.StartStationId, opt => opt.MapFrom(dest => dest.StartStationId))
                .ForPath(source => source.EndStationId, opt => opt.MapFrom(dest => dest.EndStationId))
                .ForPath(source => source.ArriveTime, opt => opt.MapFrom(dest => dest.ArriveTime))
                .ForPath(source => source.DepartureTime, opt => opt.MapFrom(dest => dest.DepartureTime))
                .ForPath(source => source.Distance, opt => opt.MapFrom(dest => dest.Distance))
                .ForPath(source => source.Line, opt => opt.MapFrom(dest => dest.Line))
                .ForPath(source => source.OrderNumber, opt => opt.MapFrom(dest => dest.OrderNumber));

            // Does not work
            CreateMap<Train, TrainDTO>()
                .ForMember(dest => dest.TrainType, opt => opt.MapFrom(source => source.TrainType))
                .ForMember(dest => dest.Connections, opt => opt.MapFrom(source => source.Connections))
                .ForMember(dest => dest.TrainLayout, opt => opt.MapFrom(source => source.Cars));
            CreateMap<Train, TrainDetails>()
                .ForMember(dest => dest.TrainType, opt => opt.MapFrom(source => source.TrainType))
                .ForMember(dest => dest.DepartureTime, opt => opt.MapFrom(source => source.Connections.OrderBy(x => x.OrderNumber).First().DepartureTime))
                .ForMember(dest => dest.ArrivalTime, opt => opt.MapFrom(source => source.Connections.OrderBy(x => x.OrderNumber).Last().ArriveTime))
                .ForMember(dest => dest.DepartureStation, opt => opt.MapFrom(source => source.Connections.OrderBy(x => x.OrderNumber).First().StartStation.Name))
                .ForMember(dest => dest.ArrivalStation, opt => opt.MapFrom(source => source.Connections.OrderBy(x => x.OrderNumber).Last().EndStation.Name))
                .ForMember(dest => dest.TotalDuration, opt => opt.MapFrom(source => (source.Connections.OrderBy(x => x.OrderNumber).Last().ArriveTime - source.Connections.OrderBy(x => x.OrderNumber).First().DepartureTime).ToString()))
                .ForMember(dest => dest.StationCount, opt => opt.MapFrom(source => source.Connections.Count));

            CreateMap<Seat, SeatDTOClient>()
                .ForMember(dest => dest.SeatId, opt => opt.MapFrom(source => source.SeatId));

            CreateMap<Car, CarDTOClient>()
                .ForMember(dest => dest.CarId, opt => opt.MapFrom(source => source.CarId))
                .ForMember(dest => dest.CarType, opt => opt.MapFrom(source => source.CarType))
                .ForMember(dest => dest.Seats, opt => opt.MapFrom(source => source.Seats));

            CreateMap<Connection, ConnectionDTOClient>()
                .ForMember(dest => dest.StartStationId, opt => opt.MapFrom(source => source.StartStationId))
                .ForMember(dest => dest.EndStationId, opt => opt.MapFrom(source => source.EndStationId))
                .ForMember(dest => dest.ArriveTime, opt => opt.MapFrom(source => source.ArriveTime.ToString()))
                .ForMember(dest => dest.DepartureTime, opt => opt.MapFrom(source => source.DepartureTime.ToString()))
                .ForMember(dest => dest.Distance, opt => opt.MapFrom(source => source.Distance))
                .ForMember(dest => dest.Line, opt => opt.MapFrom(source => source.Line))
                .ForMember(dest => dest.OrderNumber, opt => opt.MapFrom(source => source.OrderNumber));

            CreateMap<Train, TrainDTOClient>()
                .ForMember(dest => dest.TrainId, opt => opt.MapFrom(source => source.TrainId))
                .ForMember(dest => dest.TrainType, opt => opt.MapFrom(source => source.TrainType))
                .ForMember(dest => dest.Cars, opt => opt.MapFrom(source => source.Cars))
                .ForMember(dest => dest.Connections, opt => opt.MapFrom(source => source.Connections));
        }
    }
}
