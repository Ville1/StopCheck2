using Microsoft.Extensions.Configuration;

namespace StopCheck2.Utils
{
    public class Config
    {
        public static void Initialize(IConfiguration configuration)
        {
            TimeFormat = configuration.GetValue<string>("TimeFormat");
            HSLRestUrlStop = configuration.GetValue<string>("HSLRestUrlStop");
            UsesHttps = configuration.GetValue<bool>("UsesHttps");
        }

        public static string TimeFormat { get; private set; }
        public static string HSLRestUrlStop { get; private set; }
        public static bool UsesHttps { get; private set; }
    }
}