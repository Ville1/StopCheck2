using System.Collections.Generic;

namespace StopCheck2.Data.API
{
    public interface IAPI
    {
        Stop GetStop(string id);
        List<Stop> Search(string search);
    }
}
