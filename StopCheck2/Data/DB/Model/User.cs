using Google.Cloud.Firestore;
using StopCheck2.Utils;
using System;
using System.Collections.Generic;

namespace StopCheck2.Data.DB.Model
{
    [FirestoreData]
    public class User : IDBModel
    {
        public string Id { get; set; }

        [FirestoreProperty]
        public string Username { get; set; }
        [FirestoreProperty]
        public string Password { get; set; }
        [FirestoreProperty]
        public DateTime Created { get; set; }
        [FirestoreProperty]
        public DateTime Updated { get; set; }
        [FirestoreProperty(Name = "Roles")]
        public List<DocumentReference> RolesReference { get; set; }

        [Reference("RolesReference")]
        public List<Role> Roles { get; set; }

        public bool HasRight(Constants.Rights right)
        {
            return Roles.Exists(x => x.Rights.Exists(y => y == right));
        }
    }
}
