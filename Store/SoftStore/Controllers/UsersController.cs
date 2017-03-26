using System.Security.Cryptography.X509Certificates;
using Ninject;
using SimpleHttpServer.Models;
using SimpleHttpServer.Utilities;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SoftStore.BindingModels;
using SoftStore.Models;
using SoftStore.Services;
using SoftStore.Services.Contracts;
using SoftStore.Utilities;

namespace SoftStore.Controllers
{
    public class UsersController : Controller
    {
        [Inject]
        private IUsersService service;

        public UsersController()
        {
            this.service = DependencyContainer.DependencyContainer.Kernel.Get<IUsersService>();
        }

        [HttpGet]
        public IActionResult Register(HttpSession session, HttpResponse response)
        {
            if (AuthenticationManager.IsUserAuthenticated(session.Id))
            {
                this.Redirect(response, "/home/index");
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public void Register(HttpSession session, HttpResponse response, RegisterUserBm bind)
        {
            if (AuthenticationManager.IsUserAuthenticated(session.Id))
            {
                this.Redirect(response, "/home/index");
                return;
            }

            if (!this.service.IsBindModelValid(bind))
            {
                this.Redirect(response, "/home/index");
                return;
            }

            this.service.RegisterUser(bind);
            this.Redirect(response, "/users/login");
        }

        [HttpGet]
        public IActionResult Login(HttpResponse response, HttpSession session)
        {
            if (AuthenticationManager.IsUserAuthenticated(session.Id))
            {
                this.Redirect(response, "/home/index");
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public void Login(HttpSession session, HttpResponse response, LoginUserBm bind)
        {
            if (AuthenticationManager.IsUserAuthenticated(session.Id))
            {
                this.Redirect(response, "/home/index");
                return;
            }

            if (this.service.IsLoginSuccessful(bind, session.Id))
            {
                this.Redirect(response, "/home/index");
                return;
            }

            this.Redirect(response, "/users/login");
        }

        [HttpGet]
        public void Logout(HttpSession session, HttpResponse response)
        {
            if (!AuthenticationManager.IsUserAuthenticated(session.Id))
            {
                this.Redirect(response, "/users/login");
                return;
            }

            AuthenticationManager.Logout(response, session);
            this.Redirect(response, "/users/login");
        }
    }
}
