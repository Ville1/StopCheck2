using Google.Cloud.Firestore;
using System;

namespace StopCheck2.Data.DB.Model
{
    [FirestoreData]
    public class Bookmark : IDBModel
    {
        public string Id { get; set; }

        [FirestoreProperty]
        public string Name { get; set; }
        [FirestoreProperty]
        public string StopId { get; set; }
        [FirestoreProperty]
        public DateTime Created { get; set; }
        [FirestoreProperty]
        public DateTime Updated { get; set; }
        [FirestoreProperty(Name = "Owner")]
        public DocumentReference OwnerReference { get; set; }

        [Reference("OwnerReference")]
        public User Owner { get; set; }

        public override string ToString()
        {
            return string.Format("{0} Id: {1}", Name, Id);
        }
    }
}
