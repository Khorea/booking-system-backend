using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackend.Models.DTOs
{
    public class TrainDTOClient
	{
        public TrainDTOClient(int trainID, string trainType, List<CarDTOClient> cars, List<ConnectionDTOClient> connections)
        {
            TrainId = trainID;
            TrainType = trainType;
            Cars = cars;
            Connections = connections;
        }

        public int TrainId { get; set; }
        public string TrainType { get; set; }
        public List<CarDTOClient> Cars { get; set; }
        public List<ConnectionDTOClient> Connections { get; set; }
    }
}
