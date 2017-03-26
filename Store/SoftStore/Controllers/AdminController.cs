using System;
using System.Collections;
using System.Collections.Generic;
using Ninject;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;
using SoftStore.BindingModels;
using SoftStore.Models;
using SoftStore.Services.Contracts;
using SoftStore.Utilities;
using SoftStore.ViewModels;
using static SoftStore.DependencyContainer.DependencyContainer;

namespace SoftStore.Controllers
{
    public class AdminController : Controller
    {
        private IAdminService service;

        public AdminController()
        {
            this.service = Kernel.Get<IAdminService>();
        }

        [HttpGet]
        public IActionResult Newgame(HttpSession session, HttpResponse response)
        {
            User admin = this.GetAuthenticatedAdmin(response, session.Id);

            if (admin == null)
            {
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public void Newgame(HttpSession session, HttpResponse response, GameBm bind)
        {
            User admin = this.GetAuthenticatedAdmin(response, session.Id);

            if (admin == null)
            {
                return;
            }

            if (!this.service.IsGameValid(bind))
            {
                this.Redirect(response, "/admin/newgame");
                return;
            }

            this.service.AddGame(bind);
            this.Redirect(response, "/admin/all");
        }

        [HttpGet]
        public IActionResult<IEnumerable<AllGameVm>> All(HttpResponse response, HttpSession session)
        {
            User admin = this.GetAuthenticatedAdmin(response, session.Id);

            if (admin == null)
            {
                return null;
            }

            IEnumerable<AllGameVm> vms = this.service.GetAllGamesVms();

            return this.View(vms);
        }

        [HttpGet]
        public IActionResult<EditGameVm> Edit(HttpResponse response, HttpSession session, int id)
        {
            User admin = this.GetAuthenticatedAdmin(response, session.Id);

            if (admin == null)
            {
                return null;
            }

            EditGameVm vm = this.service.GetEditVm(id);
            return this.View(vm);
        }

        [HttpPost]
        public void Edit(HttpResponse response, HttpSession session, GameBm bind)
        {
            User admin = this.GetAuthenticatedAdmin(response, session.Id);

            if (admin == null)
            {
                return;
            }

            if (!this.service.IsGameValid(bind))
            {
                this.Redirect(response, $"/admin/edit?id={bind.Id}");
                return;
            }

            this.service.UpdateBindVm(bind);
            this.Redirect(response, "/admin/all");
        }

        [HttpGet]
        public IActionResult<DeleteGameVm> Delete(HttpResponse response, HttpSession session, int id)
        {
            User admin = this.GetAuthenticatedAdmin(response, session.Id);

            if (admin == null)
            {
                return null;
            }

            DeleteGameVm vm = this.service.GetDeleteVm(id);  
            return this.View(vm);
        }

        [HttpPost]
        public void Delete(HttpResponse response, HttpSession session, DeleteGameBm bind)
        {
            User admin = this.GetAuthenticatedAdmin(response, session.Id);

            if (admin == null)
            {
                return;
            }       

            this.service.DeleteGame(bind);
            this.Redirect(response, "/admin/all");
        }

        private User GetAuthenticatedAdmin(HttpResponse response, string sessionId)
        {
            if (!AuthenticationManager.IsUserAuthenticated(sessionId))
            {
                this.Redirect(response, "/users/login");
                return null;
            }

            User currentUser = AuthenticationManager.GetAuthenticatedUser(sessionId);
            if (!currentUser.IsAdmin)
            {
                this.Redirect(response, "/home/index");
                return null;
            }

            return currentUser;
        }


    }
}
