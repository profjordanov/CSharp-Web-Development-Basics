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
    using System.Collections.Generic;
    using Utilities;
    using ViewModels;

    public class CategoriesController : Controller
    {
        private CategoriesService service;

        public CategoriesController()
        {
            this.service = new CategoriesService();
        }

        [HttpGet]
        public IActionResult<AllViewModel> All(HttpSession session, HttpResponse response)
        {
            User activeUser = this.GetAuthenticatedUser(response, session);

            AllViewModel viewModel = this.service.GetAllViewModel(activeUser);

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult New(HttpResponse response, HttpSession session)
        {
            this.GetAuthenticatedUser(response, session);
            return this.View();
        }

        [HttpPost]
        public void New(HttpResponse response, HttpSession session, NewCategoryBindingModel bind)
        {
            this.GetAuthenticatedUser(response, session);

            if (!this.service.IsNewCategoryValid(bind))
            {
                this.Redirect(response, "/categories/new");
            }

            this.service.AddNewCategory(bind);
            this.Redirect(response, "/categories/all");
        }

        [HttpGet]
        public void Delete(HttpResponse response, HttpSession session, int id)
        {
            this.GetAuthenticatedUser(response, session);

            this.service.DeleteCategory(id);
            this.Redirect(response, "/categories/all");
        }

        [HttpGet]
        public IActionResult<EditCategoryViewModel> Edit
            (HttpResponse response, HttpSession session, int id)
        {
            User user = this.GetAuthenticatedUser(response, session);
            if (user == null)
                return null;

            EditCategoryViewModel viewModel = this.service.GetEditCategoryVM(id);

            return this.View(viewModel);
        }

        [HttpPost]
        public void Edit
             (HttpResponse response, HttpSession session, EditCategoryBM bind)
        {
            User user = this.GetAuthenticatedUser(response, session);
            if (user == null)
            {
                return;
            }

            this.service.EditCategoryEntity(bind);
            this.Redirect(response, "/categories/all");
        }

        public IActionResult<IEnumerable<TopicVM>> Topics(HttpSession session, string categoryName)
        {
            AuthenticationManager.GetAuthenticatedUser(session.Id);

            IEnumerable<TopicVM> topics = this.service.GetCategoryTopicsVms(categoryName);
            return this.View(topics);
        }

        private User GetAuthenticatedUser(HttpResponse response, HttpSession session)
        {
            if (!AuthenticationManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/forum/login");
                return null;
            }

            User activeUser = AuthenticationManager.GetAuthenticatedUser(session.Id);
            if (!activeUser.IsAdmin)
            {
                this.Redirect(response, "/home/topics");
            }

            return activeUser;
        }
    }
}
