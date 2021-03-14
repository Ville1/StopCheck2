using Google.Cloud.Firestore;
using StopCheck2.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StopCheck2.Data.DB
{
    public class Repository<T>
    {
        private string collectionName;

        private static FirestoreDb Firestore { get { return FirestoreDb.Create(Config.GoogleCloudProjectId); } }
        private CollectionReference Collection { get { return Firestore.Collection(collectionName); } }

        public Repository(string collectionName)
        {
            this.collectionName = collectionName;
        }

        public async Task<List<T>> GetAll()
        {
            QuerySnapshot snapshot = await Collection.GetSnapshotAsync();
            return snapshot.Documents.Select(x => x.ConvertTo<T>()).ToList();
        }

        public async Task<T> Save(T obj)
        {
            DocumentReference documentReference = await Collection.AddAsync(obj);
            DocumentSnapshot document = await documentReference.GetSnapshotAsync();
            return document.ConvertTo<T>();
        }
    }
}
