using Ninject.Modules;
using SoftStore.Data;
using SoftStore.Data.Contracts;
using SoftStore.Services;
using SoftStore.Services.Contracts;

namespace SoftStore.DependencyContainer
{
    public class InjectionModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IUnitOfWork>().To<UnitOfWork>();
            this.Bind<IUsersService>().To<UsersService>();
            this.Bind<IAdminService>().To<AdminService>();
            this.Bind<IHomeService>().To<HomeService>();
        }
    }
}
