using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Models.DTOs
{
    public class TrainDTO
    {
        public TrainDTO(string trainType, List<ConnectionDTO> connections, TrainLayout trainLayout)
        {
            TrainType = trainType;
            Connections = connections;
            TrainLayout = trainLayout;
        }

        public string TrainType { get; set; }
        public List<ConnectionDTO> Connections { get; set; }
        public TrainLayout TrainLayout { get; set; }
    }
}
