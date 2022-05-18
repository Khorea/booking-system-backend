using BookingSystemBackend.Models;
using BookingSystemBackend.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static BookingSystemBackend.Utils.Enums;

namespace BookingSystemBackend.Services
{
    public class LayoutService
    {
        private readonly CarService _carService;

        public LayoutService(CarService carService)
        {
            _carService = carService;
        }

        public async Task<List<Car>> CreateTrainLayout(TrainLayout trainLayout, int trainId)
        {
            List<Car> cars = new List<Car>();

            for (int i = 0; i < trainLayout.FirstClass; i++)
            {
                Car car = new Car(CarType.FirstClass, trainId);
                car = await _carService.InsertCar(car);
                cars.Add(car);
            }

            for (int i = 0; i < trainLayout.SecondClass; i++)
            {
                Car car = new Car(CarType.SecondClass, trainId);
                car = await _carService.InsertCar(car);
                cars.Add(car);
            }

            for (int i = 0; i < trainLayout.FirstClassSleeper; i++)
            {
                Car car = new Car(CarType.Sleeper, trainId);
                car = await _carService.InsertCar(car);
                cars.Add(car);
            }

            for (int i = 0; i < trainLayout.Couchette; i++)
            {
                Car car = new Car(CarType.Couchette, trainId);
                car = await _carService.InsertCar(car);
                cars.Add(car);
            }

            return cars;
        }

        public async Task ChangeLayout(int trainId, TrainLayout oldLayout, TrainLayout newLayout)
        {
            int diff = Math.Abs(oldLayout.FirstClass - newLayout.FirstClass);
            if (oldLayout.FirstClass < newLayout.FirstClass)
            {
                for (int i = 0; i < diff; i++)
                {
                    Car newCar = new Car(CarType.FirstClass, trainId);
                    await _carService.InsertCar(newCar);
                }
            } 
            else
            {
                for (int i = 0; i < diff; i++)
                {
                    await _carService.RemoveCar(trainId, CarType.FirstClass);
                }
            }

            diff = Math.Abs(oldLayout.SecondClass - newLayout.SecondClass);
            if (oldLayout.SecondClass < newLayout.SecondClass)
            {
                for (int i = 0; i < diff; i++)
                {
                    Car newCar = new Car(CarType.SecondClass, trainId);
                    await _carService.InsertCar(newCar);
                }
            }
            else
            {
                for (int i = 0; i < diff; i++)
                {
                    await _carService.RemoveCar(trainId, CarType.SecondClass);
                }
            }

            diff = Math.Abs(oldLayout.FirstClassSleeper - newLayout.FirstClassSleeper);
            if (oldLayout.FirstClassSleeper < newLayout.FirstClassSleeper)
            {
                for (int i = 0; i < diff; i++)
                {
                    Car newCar = new Car(CarType.Sleeper, trainId);
                    await _carService.InsertCar(newCar);
                }
            }
            else
            {
                for (int i = 0; i < diff; i++)
                {
                    await _carService.RemoveCar(trainId, CarType.Sleeper);
                }
            }

            diff = Math.Abs(oldLayout.Couchette - newLayout.Couchette);
            if (oldLayout.Couchette < newLayout.Couchette)
            {
                for (int i = 0; i < diff; i++)
                {
                    Car newCar = new Car(CarType.Couchette, trainId);
                    await _carService.InsertCar(newCar);
                }
            }
            else
            {
                for (int i = 0; i < diff; i++)
                {
                    await _carService.RemoveCar(trainId, CarType.Couchette);
                }
            }
        }
    }
}
