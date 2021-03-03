namespace StopCheck2.Utils
{
    public class UrlHelper
    {
        public static readonly string ERROR_PAGE = "/Error";

        public static string ParseAjaxUrl(Microsoft.AspNetCore.Http.HttpRequest request)
        {
            return string.Format("{0}://{1}/{2}", request.Scheme, request.Host, "Ajax/StopDepartures?handler=Departures");
        }
    }
}