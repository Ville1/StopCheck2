using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StopCheck2.Data;
using StopCheck2.Utils;

namespace StopCheck2.Pages.Ajax
{
    public class StopDeparturesModel : PageModel
    {
        public void OnGet()
        { }

        public JsonResult OnPostDepartures([FromBody] AjaxRequestData paramaters)
        {
            AjaxDepartures departures = new AjaxDepartures() {
                Departures = new List<AjaxDeparture>()
            };
            if (string.IsNullOrEmpty(paramaters.id)) {
                return new JsonResult(departures);
            }
            Stop stop = ApiHelper.Api.GetStop(paramaters.id);
            if(stop == null) {
                return new JsonResult(departures);
            }
            departures = new AjaxDepartures() {
                Departures = stop.Departures.Select(x => new AjaxDeparture() {
                    Headsign = x.Headsign,
                    Arrival = new AjaxDepartureTime() {
                        Realtime = x.Arrival.Realtime.ToString(Config.TimeFormat),
                        Scheduled = x.Arrival.Scheduled.ToString(Config.TimeFormat),
                        Delay = x.Arrival.Delay
                    },
                    Departure = new AjaxDepartureTime() {
                        Realtime = x.Departure.Realtime.ToString(Config.TimeFormat),
                        Scheduled = x.Departure.Scheduled.ToString(Config.TimeFormat),
                        Delay = x.Departure.Delay
                    }
                }).ToList()
            };
            return new JsonResult(departures);
        }
    }

    public class AjaxRequestData
    {
        [BindProperty]
        public string id { get; set; }
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
