using System.Collections.Generic;
using System.Threading;
using Ninject;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces.Generic;
using SoftStore.BindingModels;
using SoftStore.Models;
using SoftStore.Services;
using SoftStore.Services.Contracts;
using SoftStore.Utilities;
using SoftStore.ViewModels;
using static SoftStore.DependencyContainer.DependencyContainer;

namespace SoftStore.Controllers
{
    public class HomeController : Controller
    {
        private IHomeService service;

        public HomeController()
        {
            this.service = Kernel.Get<IHomeService>();
        }

        [HttpGet]
        public IActionResult<IEnumerable<HomeGameVm>> Index(HttpSession session, HttpResponse response, string filter)
        {
            if (!AuthenticationManager.IsUserAuthenticated(session.Id))
            {
                this.Redirect(response, "/users/login");
                return null;
            }

            User currentUser = AuthenticationManager.GetAuthenticatedUser(session.Id);

            IEnumerable<HomeGameVm> vms = this.service.GetHomeVms(filter, currentUser);

            return this.View(vms);
        }

        [HttpGet]
        public IActionResult<DetailsGameVm> Details(HttpSession session, HttpResponse response, int id)
        {
            if (!AuthenticationManager.IsUserAuthenticated(session.Id))
            {
                this.Redirect(response, "/users/login");
                return null;
            }

            User currentUser = AuthenticationManager.GetAuthenticatedUser(session.Id);

            DetailsGameVm vm = this.service.GetDetailedGameVm(id);

            return this.View(vm);
        }

        [HttpPost]
        public void Buy(HttpSession session, HttpResponse response, BuyGameBm bind)
        {
            if (!AuthenticationManager.IsUserAuthenticated(session.Id))
            {
                this.Redirect(response, "/users/login");
                return;
            }

            User currentUser = AuthenticationManager.GetAuthenticatedUser(session.Id);

            this.service.BuyGameForUser(currentUser, bind);
            this.Redirect(response, "/home/index?filter=owned");
        }
    }
}
