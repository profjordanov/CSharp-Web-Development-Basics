using PizzaMore.Data;
using PizzaMore.Utilities;
using System.Collections.Generic;

namespace AddPizza
{
    class AddPizza
    {
        private static IDictionary<string, string> PostParams;
        private static Header Header = new Header();
        static void Main(string[] args)
        {
            var session = WebUtil.GetSession();
            if (session == null)
            {
                Header.Print();
                WebUtil.PageNotAllowed();
                return;
            }

            if (WebUtil.IsGet())
            {
                //Show form to add new pizza suggestion
                ShowPage();
            }
            else if (WebUtil.IsPost())
            {
                //add suggestion to the database
                PostParams = WebUtil.RetrievePostParameters();
                using (var ctx = new PizzaMoreContext())
                {
                    var user = ctx.Users.Find(session.UserId);
                    user.Suggestions.Add(new Pizza()
                    {
                        Title = PostParams["title"],
                        Recipe = PostParams["recipe"],
                        ImageUrl = PostParams["url"],
                        UpVotes = 0,
                        DownVotes = 0,
                        OwnerId = user.Id
                    });
                    ctx.SaveChanges();
                }
                ShowPage();
            }
        }

        private static void ShowPage()
        {
            Header.Print();
            WebUtil.PrintFileContent("../../htdocs/pm/addpizza.html");
        }
    }
}
