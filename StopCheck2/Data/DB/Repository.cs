using Google.Cloud.Firestore;
using StopCheck2.Data.DB.Model;
using StopCheck2.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace StopCheck2.Data.DB
{
    public class Repository<T> where T : IDBModel
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
            try {
                QuerySnapshot snapshot = await Collection.GetSnapshotAsync();
                List<T> list = snapshot.Documents.Select(x => Convert(x)).ToList();
                foreach (T item in list) {
                    foreach (PropertyInfo propertyInfo in item.GetType().GetProperties()) {
                        ReferenceAttribute attribute = propertyInfo.GetCustomAttribute<ReferenceAttribute>();
                        if (attribute != null) {
                            PropertyInfo documentReferencePropertyInfo = item.GetType().GetProperties().FirstOrDefault(x => x.Name == attribute.PropertyName);
                            if (documentReferencePropertyInfo == null) {
                                throw new Exception(string.Format("Property with name {0} does not exist", attribute.PropertyName));
                            }
                            if (propertyInfo.PropertyType.GetInterfaces().Contains(typeof(IList))) {
                                if (documentReferencePropertyInfo.PropertyType.GenericTypeArguments.Length != 1 || documentReferencePropertyInfo.PropertyType.GenericTypeArguments[0] != typeof(DocumentReference)) {
                                    throw new Exception(string.Format("Property name {0} is not List<DocumentReference>", attribute.PropertyName));
                                }
                                List<DocumentReference> referenceList = documentReferencePropertyInfo.GetValue(item) as List<DocumentReference>;
                                Type type = propertyInfo.PropertyType.GenericTypeArguments[0];
                                IList list2 = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(type));
                                foreach (DocumentReference reference in referenceList) {
                                    DocumentSnapshot snapshot2 = await reference.GetSnapshotAsync();
                                    MethodInfo convertMethod = snapshot2.GetType().GetMethod("ConvertTo").MakeGenericMethod(new Type[] { type });
                                    list2.Add(convertMethod.Invoke(snapshot2, new object[] { }));
                                }
                                propertyInfo.SetValue(item, list2);
                            } else {
                                //TODO: this
                                throw new NotImplementedException();
                            }
                        }
                    }
                }
                return list;
            } catch(Exception exception) {
                Logger.LogException(exception);
                return new List<T>();
            }
        }

        public async Task<T> Save(T obj)
        {
            try {
                DocumentReference documentReference = await Collection.AddAsync(obj);
                DocumentSnapshot document = await documentReference.GetSnapshotAsync();
                return Convert(document);
            } catch(Exception exception) {
                Logger.LogException(exception);
                return obj;
            }
        }

        public async Task<bool> Exists(string id)
        {
            try {
                List<T> all = await GetAll();
                return all.Exists(x => x.Id == id);
            } catch (Exception exception) {
                Logger.LogException(exception);
                return false;
            }
        }

        public async Task<bool> Delete(string id)
        {
            try {
                QuerySnapshot snapshot = await Collection.GetSnapshotAsync();
                DocumentSnapshot document = snapshot.Documents.FirstOrDefault(x => x.Id == id);
                if (document == null) {
                    return false;
                }
                WriteResult result = await document.Reference.DeleteAsync();
                return true;
            } catch (Exception exception) {
                Logger.LogException(exception);
                return false;
            }
        }

        private T Convert(DocumentSnapshot snapshot)
        {
            T obj = snapshot.ConvertTo<T>();
            obj.Id = snapshot.Id;
            return obj;
        }
    }
}
