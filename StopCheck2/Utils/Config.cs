using Microsoft.Extensions.Configuration;

namespace StopCheck2.Utils
{
    public class Config
    {
        public static void Initialize(IConfiguration configuration)
        {
            TimeFormat = configuration.GetValue<string>("TimeFormat");
            HSLRestUrlStop = configuration.GetValue<string>("HSLRestUrlStop");
        }

        public static string TimeFormat { get; private set; }
        public static string HSLRestUrlStop { get; private set; }
    }
}