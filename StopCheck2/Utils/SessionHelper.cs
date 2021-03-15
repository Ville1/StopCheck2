using Microsoft.AspNetCore.Http;
using System.Linq;
using StopCheck2.Data.DB;
using StopCheck2.Data.DB.Model;

namespace StopCheck2.Utils
{
    public class SessionHelper
    {
        private static readonly string USERNAME_KEY = "username";
        private static readonly string PASSWORD_KEY = "password";

        public static void SetCurrentUser(HttpContext context, User user)
        {
            if(user == null) {
                context.Session.Remove(USERNAME_KEY);
                context.Session.Remove(PASSWORD_KEY);
            } else {
                context.Session.SetString(USERNAME_KEY, user.Username);
                context.Session.SetString(PASSWORD_KEY, user.Password);
            }
        }

        public static void ClearCurrentUser(HttpContext context)
        {
            context.Session.Remove(USERNAME_KEY);
            context.Session.Remove(PASSWORD_KEY);
        }

        public static User GetCurrentUser(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Session.GetString(USERNAME_KEY))) {
                return null;
            }
            return Database.Users.GetAll().Result.FirstOrDefault(x => x.Username == context.Session.GetString(USERNAME_KEY) && x.Password == context.Session.GetString(PASSWORD_KEY));
        }
    }
}
