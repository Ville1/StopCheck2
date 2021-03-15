using Google.Cloud.Firestore;
using StopCheck2.Utils;
using System.Collections.Generic;
using System.Linq;

namespace StopCheck2.Data.DB.Model
{
    [FirestoreData]
    public class Role : IDBModel
    {
        public string Id { get; set; }

        [FirestoreProperty]
        public string Name { get; set; }
        [FirestoreProperty(Name = "Rights")]
        public List<int> RightsInt { get; set; }

        public List<Constants.Rights> Rights { get { return RightsInt.Select(x => (Constants.Rights)x).ToList(); } }
    }
}
