using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace SoftStore.DependencyContainer
{
    public class DependencyContainer
    {
        private static StandardKernel kernel;

        public static StandardKernel Kernel =>
            kernel ?? (kernel = new StandardKernel(new InjectionModule())); 
    }
}
