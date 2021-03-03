using System;
using System.Collections.Generic;

namespace StopCheck2.Data.API.HSL
{
    public class HSLStopSearchData
    {
        public HSLStopSearchData_data data { get; set; }

        internal List<Stop> Select()
        {
            throw new NotImplementedException();
        }
    }

    public class HSLStopSearchData_data
    {
        public List<HSLStopSearchData_stop> stops { get; set; }
    }

    public class HSLStopSearchData_stop
    {
        public string gtfsId { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public float lat { get; set; }
        public float lon { get; set; }
    }
}