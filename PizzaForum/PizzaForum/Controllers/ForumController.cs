namespace PizzaForum.Controllers
{
    using BindingModels;
    using Models;
    using Services;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using Utilities;
    using ViewModels;

    public class ForumController : Controller
    {
        private ForumService service;

        public ForumController()
        {
            this.service = new ForumService();
        }

        [HttpGet]
        public IActionResult Register(HttpSession session, HttpResponse response)
        {
            if (this.IsAuthenticated(session.Id, response))
            {
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Register(HttpResponse response, RegisterUserBindingModel rubm)
        {
            if (!this.service.IsRegisterModelValid(rubm))
            {
                this.Redirect(response, "/forum/register");
                return null;
            }

            User user = this.service.GetUserFromRegisterBind(rubm);
            this.service.RegisterUser(user);

            this.Redirect(response, "/forum/login");
            return null;
        }

        [HttpGet]
        public IActionResult Login(HttpSession session, HttpResponse response)
        {
            if (this.IsAuthenticated(session.Id, response))
            {
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Login(
            HttpResponse response, HttpSession session, LoginUserBindingModel lubm)
        {
            if (!this.service.IsLoginModelValid(lubm))
            {
                this.Redirect(response, "/forum/login");
                return null;
            }

            User user = this.service.GetUserFromLoginBind(lubm);

            this.service.LoginUser(user, session.Id);
            this.Redirect(response, "/home/topics");
            return null;
        }

        [HttpGet]
        public void Logout(HttpResponse response, HttpSession session)
        {
            AuthenticationManager.Logout(response, session.Id);
            this.Redirect(response, "/home/topics");
        }

        [HttpGet]
        public IActionResult<ProfileVM> Profile(HttpSession session, int id)
        {
            User user = AuthenticationManager.GetAuthenticatedUser(session.Id);

            int currentUserId = -1;
            if (user != null)
            {
                currentUserId = user.Id;
            }

            ProfileVM topics = this.service.GetProfileVm(id, currentUserId);

            return this.View(topics);
        }

        private bool IsAuthenticated(string sessionId, HttpResponse response)
        {
            if (AuthenticationManager.IsAuthenticated(sessionId))
            {
                this.Redirect(response, "/home/topics");
                return true;
            }

            return false;
        }
    }
}
