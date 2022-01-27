using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Models.DTOs
{
    public class TrainDTO
    {
        public TrainDTO(string trainType, List<StationDTO> stations, TrainLayout trainLayout)
        {
            TrainType = trainType;
            Stations = stations;
            TrainLayout = trainLayout;
        }

        public string TrainType { get; set; }
        public List<StationDTO> Stations { get; set; }
        public TrainLayout TrainLayout { get; set; }
    }
}
