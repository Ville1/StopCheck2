namespace StopCheck2.Utils
{
    public class UrlHelper
    {
        public static readonly string ERROR_PAGE = "~/Views/Error.aspx";

        public static string ParseAjaxUrl()
        {
            return null;
            //System.Net.WebRequest request
            //return string.Format("{0}://{1}/{2}", request.Url.Scheme, request.Url.Authority, "Ajax/StopDepartures.asmx/GetDepartures");
        }
    }
}