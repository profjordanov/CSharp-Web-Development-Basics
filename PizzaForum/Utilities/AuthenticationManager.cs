namespace PizzaForum.Utilities
{
    using System.Linq;
    using Models;
    using SimpleHttpServer.Models;
    using static Data.Data;
    using SimpleHttpServer.Utilities;

    class AuthenticationManager
    {
        public static bool IsAuthenticated(string sessionId)
        {
            return Context.Logins.Any(login => login.SessionId == sessionId && login.IsActive);
        }

        public static User GetAuthenticatedUser(string sessionId)
        {
            User user = Context.Logins.FirstOrDefault(login => login.SessionId == sessionId && login.IsActive)?.User;
            if (user != null)
            {      
                ViewBag.Bag["username"] = user.Username;
            }

            return user;
        }

        public static void Logout(HttpResponse response, string sessionId)
        {
            ViewBag.Bag["username"] = null;
            Login currentLogin = Context.Logins.FirstOrDefault(login => login.SessionId == sessionId);
            currentLogin.IsActive = false;
            Context.SaveChanges();

            var session = SessionCreator.Create();
            var sessionCookie = new Cookie("sessionId", session.Id + "; HttpOnly; path=/");
            response.Header.AddCookie(sessionCookie);
        }
    }
}
