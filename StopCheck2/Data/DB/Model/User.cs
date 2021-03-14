using Google.Cloud.Firestore;

namespace StopCheck2.Data.DB.Model
{
    [FirestoreData]
    public class User
    {
        [FirestoreProperty]
        public string Username { get; set; }
        [FirestoreProperty]
        public string Password { get; set; }
    }
}
