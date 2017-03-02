namespace PizzaForum.Services
{
    using Data.Contracts;
    using DepedencyContainer;
    using Ninject;

    public abstract class Service
    {
        public Service()
        {
            this.Context = DependencyKernel.Kernel.Get<IUnitOfWork>();
        }

        protected IUnitOfWork Context { get; }
    }
}
