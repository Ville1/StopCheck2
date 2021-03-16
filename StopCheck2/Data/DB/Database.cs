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

        private static Repository<Role> roles;
        public static Repository<Role> Roles
        {
            get {
                if (roles == null) {
                    roles = new Repository<Role>("roles");
                }
                return roles;
            }
        }

        private static Repository<Bookmark> bookmarks;
        public static Repository<Bookmark> Bookmarks
        {
            get {
                if (bookmarks == null) {
                    bookmarks = new Repository<Bookmark>("bookmarks");
                }
                return bookmarks;
            }
        }
    }
}
