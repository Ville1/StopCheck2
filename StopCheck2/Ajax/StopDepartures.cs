using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StopCheck2.Ajax
{
    [Route("api/[controller]")]
    [ApiController]
    public class StopDepartures : ControllerBase
    {
        // GET: api/<StopDepartures>
        [HttpGet]
        public AjaxDepartures GetDepartures(string id)
        {
            return null;
        }
    }

    public class AjaxDepartures
    {
        public List<AjaxDeparture> Departures { get; set; }
    }

    public class AjaxDeparture
    {
        public string Headsign { get; set; }
        public AjaxDepartureTime Arrival { get; set; }
        public AjaxDepartureTime Departure { get; set; }
    }

    public class AjaxDepartureTime
    {
        public string Realtime { get; set; }
        public string Scheduled { get; set; }
        public int Delay { get; set; }
    }
}
