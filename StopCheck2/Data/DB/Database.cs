using StopCheck2.Data.DB.Model;

namespace StopCheck2.Data.DB
{
    public class Database
    {

        private static Repository<User> users;
        public static Repository<User> Users {
            get {
                if(users == null) {
                    users = new Repository<User>("users");
                }
                return users;
            }
        }
    }
}
