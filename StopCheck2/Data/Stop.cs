using System.Collections.Generic;

namespace StopCheck2.Data
{
    public class Stop
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }

        public List<StopDeparture> Departures { get; set; }
    }
}