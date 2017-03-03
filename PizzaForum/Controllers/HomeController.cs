using System.Collections.Generic;
using PizzaForum.Services;
using PizzaForum.Utilities;
using PizzaForum.ViewModels;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;

namespace PizzaForum.Controllers
{
    public class HomeController : Controller
    {
        private HomeService service;

        public HomeController()
        {
            service = new HomeService();
        }

        [HttpGet]
        public IActionResult<IEnumerable<TopicVM>>  Topics(HttpSession session)
        {
            AuthenticationManager.GetAuthenticatedUser(session.Id);
            IEnumerable<TopicVM> topics = service.GetTopTenLatestTopics();
            return this.View(topics);
        }
    }
}