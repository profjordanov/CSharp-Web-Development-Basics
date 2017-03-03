using PizzaForum.Data;

namespace PizzaForum.Services
{
    public class Service
    {
        protected PizzaForumContext Context { get; }
        public Service()
        {
            this.Context = Data.Data.Context;
        }
    }
}