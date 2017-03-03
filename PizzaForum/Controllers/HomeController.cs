using PizzaForum.Services;
using PizzaForum.Utilities;
using PizzaForum.ViewModels;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces.Generic;
using System.Collections.Generic;

namespace PizzaForum.Controllers
{
    public class HomeController : Controller
    {
        private HomeService service;

        public HomeController()
        {
            this.service = new HomeService();
        }

        [HttpGet]
        public IActionResult<IEnumerable<TopicVM>> Topics(HttpSession session)
        {
            AuthenticationManager.GetAuthenticatedUser(session.Id);
            IEnumerable<TopicVM> topics = this.service.GetTopTenLatestTopics();

            return this.View(topics);
        }

        [HttpGet]
        public IActionResult<IEnumerable<string>> Categories(HttpSession session)
        {
            AuthenticationManager.GetAuthenticatedUser(session.Id);
            IEnumerable<string> categoryNames = this.service.GetCategoriesNames();
            return this.View(categoryNames);
        }
    }
}
