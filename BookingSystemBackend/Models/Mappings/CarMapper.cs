using AutoMapper;
using BookingSystemBackend.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Models.Mappings
{
    public class CarMapper : Profile
    {
        public CarMapper()
        {
            CreateMap<ICollection<Car>, TrainLayout>()
                .ForMember(dest => dest.FirstClass, opt => opt.MapFrom(source => source.ToList().FindAll(car => car.CarType.Equals("First Class")).Count))
                .ForMember(dest => dest.SecondClass, opt => opt.MapFrom(source => source.ToList().FindAll(car => car.CarType.Equals("Second Class")).Count))
                .ForMember(dest => dest.FirstClassSleeper, opt => opt.MapFrom(source => source.ToList().FindAll(car => car.CarType.Equals("First Class Sleeper")).Count))
                .ForMember(dest => dest.Couchette, opt => opt.MapFrom(source => source.ToList().FindAll(car => car.CarType.Equals("Couchette")).Count));
        }
    }
}
