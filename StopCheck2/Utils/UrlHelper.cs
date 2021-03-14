namespace StopCheck2.Utils
{
    public class UrlHelper
    {
        public static readonly string INDEX_PAGE = "/Index";
        public static readonly string ERROR_PAGE = "/Error";

        public static string ParseAjaxUrl(Microsoft.AspNetCore.Http.HttpRequest request)
        {
            //request.Scheme doesn't work because Google Cloud load balancing?
            //return string.Format("{0}://{1}/{2}", request.Scheme, request.Host, "Ajax/StopDepartures?handler=Departures");
            return string.Format("{0}://{1}/{2}", Config.UsesHttps ? "https" : "http", request.Host, "Ajax/StopDepartures?handler=Departures");
        }
    }
}