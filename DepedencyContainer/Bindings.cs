using Ninject.Modules;
using PizzaForum.Data;
using PizzaForum.Data.Contracts;

namespace PizzaForum.DepedencyContainer
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
