using PizzaMore.Data;
using PizzaMore.Utilities;
using System.Collections.Generic;

namespace signup
{
    class SignUp
    {
        public static IDictionary<string, string> RequestParameters;
        public static Header Header = new Header();
        static void Main()
        {
            if (WebUtil.IsPost())
            {
                RegisterUser();
            }

            ShowPage();
        }

        private static void RegisterUser()
        {
            RequestParameters = WebUtil.RetrievePostParameters();
            var email = RequestParameters["email"];
            var password = RequestParameters["password"];
            var user = new User()
            {
                Email = email,
                Password = PasswordHasher.Hash(password)
            };

            using (var ctx = new PizzaMoreContext())
            {
                ctx.Users.Add(user);
                ctx.SaveChanges();
            }
        }

        private static void ShowPage()
        {
            Header.Print();
            WebUtil.PrintFileContent("../../htdocs/pm/signup.html");
        }
    }
}
