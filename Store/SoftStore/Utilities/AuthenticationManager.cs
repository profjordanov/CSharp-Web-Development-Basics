using System.Diagnostics;
using System.Linq;
using SimpleHttpServer.Models;
using SimpleHttpServer.Utilities;
using SoftStore.Models;

namespace SoftStore.Utilities
{
    using static Data.Data;
    public class AuthenticationManager
    {
        public static bool IsUserAuthenticated(string sessionId)
        {
            if (Context.Logins.Any(login => login.SessionId == sessionId && login.IsActive))
            {
                return true;
            }

            return false;
        }
                       
        public static User GetAuthenticatedUser(string sessionId)
        {
            var currentLogin = Context.Logins.FirstOrDefault(login => login.SessionId == sessionId && login.IsActive);
            return currentLogin?.User;
        }

        public static void Logout(HttpResponse response, HttpSession sesion)
        {
            Login login = Context.Logins.FirstOrDefault(login1 => login1.SessionId == sesion.Id && login1.IsActive);
            login.IsActive = false;
            Context.SaveChanges();

            var newSession = SessionCreator.Create();
            var sessionCookie = new Cookie("sessionId", newSession.Id + "; HttpOnly; path=/");
            response.Header.AddCookie(sessionCookie);
        }
    }
}
