using Ninject;
using SoftStore.Data.Contracts;
using static SoftStore.DependencyContainer.DependencyContainer;

namespace SoftStore.Services
{
    public class Service
    {           
        private IUnitOfWork context;

        public Service()
        {
            this.context = Kernel.Get<IUnitOfWork>();
        }
            
        protected IUnitOfWork Context => this.context;
    }
}
