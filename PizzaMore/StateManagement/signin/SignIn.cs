using PizzaMore.Data;
using PizzaMore.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace signin
{
    class SignIn
    {
        public static IDictionary<string, string> RequestParameters;
        public static Header Header = new Header();

        static void Main()
        {
            if (WebUtil.IsPost())
            {
                LogIn();
            }

            ShowPage();
        }

        private static void LogIn()
        {
            RequestParameters = WebUtil.RetrievePostParameters();
            string email = RequestParameters["email"];
            string password = RequestParameters["password"];
            string hashedPassword = PasswordHasher.Hash(RequestParameters["password"]);
            using (var ctx = new PizzaMoreContext())
            {
                var user = ctx.Users.SingleOrDefault(u => u.Email == email);
                if (hashedPassword == user.Password)
                {
                    var session = new Session()
                    {
                        Id = new Random().Next().ToString(),
                        User = user
                    };

                    if (user != null)
                    {
                        Header.AddCookie(new Cookie("sid", session.Id));
                    }
                    ctx.Sessions.Add(session);
                    ctx.SaveChanges();
                }
            }
        }

        private static void ShowPage()
        {
            Header.Print();
            WebUtil.PrintFileContent("../../htdocs/pm/signin.html");
        }
    }
}