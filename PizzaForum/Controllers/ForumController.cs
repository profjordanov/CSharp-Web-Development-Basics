using System.ComponentModel;
using PizzaForum.BindingModels;
using PizzaForum.Models;
using PizzaForum.Services;
using PizzaForum.Utilities;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;

namespace PizzaForum.Controllers
{
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
             this.Redirect(response,"/forum/register");
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
        public IActionResult Login(HttpResponse response, HttpSession session, LoginUserBindingModel lubm)
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
