using System.Collections.Generic;

namespace StopCheck2.Data.API.HSL
{
    public class HSLStopData
    {
        public HSLStopData_data data { get; set; }
    }

    public class HSLStopData_data
    {
        public HSLStopData_stop stop { get; set; }
    }

    public class HSLStopData_stop
    {
        public string name { get; set; }
        public List<HSLStopData_stoptimeWithoutPatterns> stoptimesWithoutPatterns { get; set; }
    }

    public class HSLStopData_stoptimeWithoutPatterns
    {
        public int scheduledArrival { get; set; }
        public int realtimeArrival { get; set; }
        public int arrivalDelay { get; set; }
        public int scheduledDeparture { get; set; }
        public int realtimeDeparture { get; set; }
        public int departureDelay { get; set; }
        public bool realtime { get; set; }
        public string realtimeState { get; set; }
        public long serviceDay { get; set; }
        public string headsign { get; set; }
    }
}