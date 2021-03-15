namespace StopCheck2.Utils
{
    public class Constants
    {
        public static readonly string ANTIFORGERY_TOKEN_NAME = "XSRF-TOKEN";
        public static readonly string TITLE_KEY = "Title";
        public static readonly string USER_KEY = "CurrentUser";

        public enum Rights { ViewUsers, ModifyUsers }
    }
}
