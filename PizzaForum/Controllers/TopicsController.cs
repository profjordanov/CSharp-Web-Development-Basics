using System.Collections.Generic;
using PizzaForum.BindingModels;
using PizzaForum.Models;
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
    public class TopicsController : Controller
    {
        private TopicsService service;

        public TopicsController()
        {
            this.service = new TopicsService();
        }

        [HttpGet]
        public IActionResult<IEnumerable<string>> New(HttpSession session, HttpResponse response)
        {
            User currentUser = AuthenticationManager.GetAuthenticatedUser(session.Id);
            if (currentUser == null)
            {
                this.Redirect(response, "/home/topics");
                return null;
            }
            IEnumerable<string> categoryNames = service.GetCategoryNames();

            return this.View(categoryNames);
        }

        [HttpPost]

        public void New(HttpSession session, HttpResponse response, NewTopicBindingModel bind)
        {
            User user = AuthenticationManager.GetAuthenticatedUser(session.Id);

            if (user == null)
            {
                this.Redirect(response, "/home/topics");
                return;
            }
            if (!service.IsNewTopicValid(bind))
            {
                this.Redirect(response, "/topics/new");
                return;
            }
            service.AddNewTopic(bind, user);

            this.Redirect(response, "/home/topics");
        }

        [HttpGet]
        public IActionResult<DetailsVM> Details(int id, HttpSession session, HttpResponse response)
        {
            User user = AuthenticationManager.GetAuthenticatedUser(session.Id);

            if (user == null)
            {
                this.Redirect(response, "/home/topics");
                return null;
            }

            DetailsVM viewModel = service.GetDetailsVm(id);

            return this.View(viewModel);
        }

        [HttpPost]
        public void Details(HttpRequest request, HttpSession session, HttpResponse response, DetailsReplyBM bind)
        {
            User user = AuthenticationManager.GetAuthenticatedUser(session.Id);

            if (user == null)
            {
                this.Redirect(response, "/home/topics");
                return;
            }

            service.AddNewReply(bind, user);
            this.Redirect(response, request.Url);
        }
        
    }
}