using StopCheck2.Data.API;
using StopCheck2.Data.API.HSL;
namespace StopCheck2.Utils
{
    public class ApiHelper
    {
        public static IAPI Api
        {
            get {
                return new HSLAPI();
            }
        }
    }
}
