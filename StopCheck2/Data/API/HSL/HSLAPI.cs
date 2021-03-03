using Newtonsoft.Json;
using StopCheck2.Data.Rest;
using StopCheck2.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StopCheck2.Data.API.HSL
{
    public class HSLAPI : IAPI
    {
        public Stop GetStop(string id)
        {
            try {
                string response = RestHelper.Post(Config.HSLRestUrlStop, new Dictionary<string, string>() {
                { "Content-Type", "application/graphql" }
                }, "{" +
                        "stop(id: \"HSL:" + id + "\") {" +
                            @"name
                           stoptimesWithoutPatterns {
                           scheduledArrival
                           realtimeArrival
                           arrivalDelay
                           scheduledDeparture
                           realtimeDeparture
                           departureDelay
                           realtime
                           realtimeState
                           serviceDay
                           headsign
                       }
                    }
                }");
                if (string.IsNullOrEmpty(response)) {
                    throw new Exception("Empty response");
                }

                HSLStopData data = JsonConvert.DeserializeObject<HSLStopData>(response);

                List<StopDeparture> departures = new List<StopDeparture>();
                foreach(HSLStopData_stoptimeWithoutPatterns stoptime in data.data.stop.stoptimesWithoutPatterns) {
                    DateTime serviceDay = UnixTimeStampHelper.ToDateTime(stoptime.serviceDay);
                    departures.Add(new StopDeparture() {
                        Headsign = stoptime.headsign,
                        Arrival = new StopDeparture.StopDepartureTime {
                            Realtime = serviceDay.AddSeconds(stoptime.realtimeArrival),
                            Scheduled = serviceDay.AddSeconds(stoptime.scheduledArrival),
                            Delay = stoptime.arrivalDelay
                        },
                        Departure = new StopDeparture.StopDepartureTime {
                            Realtime = serviceDay.AddSeconds(stoptime.realtimeDeparture),
                            Scheduled = serviceDay.AddSeconds(stoptime.scheduledDeparture),
                            Delay = stoptime.departureDelay
                        }
                    });
                }

                return new Stop() {
                    Id = id,
                    Name = data.data.stop.name,
                    Departures = departures
                };
            } catch (Exception exception) {
                Logger.LogException(exception);
                return null;
            }
        }

        public List<Stop> Search(string search)
        {
            try {
                string response = RestHelper.Post(Config.HSLRestUrlStop, new Dictionary<string, string>() {
                { "Content-Type", "application/graphql" }
                }, "{" +
                        "stops(name: \"" + search + "\") {" +
                            @"gtfsId
                            name
                            code
                            lat
                            lon
                        }
                    }"
                );
                if (string.IsNullOrEmpty(response)) {
                    throw new Exception("Empty response");
                }

                HSLStopSearchData data = JsonConvert.DeserializeObject<HSLStopSearchData>(response);

                return data.data.stops.Select(x => new Stop() {
                    Id = x.gtfsId.Substring(x.gtfsId.IndexOf("HSL:") + 4),
                    Name = x.name,
                    Latitude = x.lat,
                    Longitude = x.lon
                }).ToList();
            } catch (Exception exception) {
                Logger.LogException(exception);
                return null;
            }
        }
    }
}