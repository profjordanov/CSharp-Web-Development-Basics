using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization.Json;
using System.Security.Authentication;
using System.Text.RegularExpressions;
using AutoMapper;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Interfaces;
using SoftStore.BindingModels;
using SoftStore.Models;
using SoftStore.Services.Contracts;
using SoftStore.Utilities;
using SoftStore.ViewModels;

namespace SoftStore.Services
{
    public class AdminService : Service, IAdminService
    {
        public void AddGame(GameBm bind)
        {
            Game gameToAdd = Mapper.Instance.Map<GameBm, Game>(bind);

            this.Context.Games.Add(gameToAdd);
            this.Context.SaveChanges();
        }

        public bool IsGameValid(GameBm bind)
        {
            if (!char.IsUpper(bind.Title[0]) || bind.Title.Length < 3 || bind.Title.Length > 100)
                return false;

            if (bind.Price <= 0 || bind.Size <= 0)
                return false;

            if (bind.Trailer.Length != 11)
                return false;

            if (bind.Description.Length < 20)
                return false;

            if (!bind.ImageThumbnail.StartsWith("http://") && !bind.ImageThumbnail.StartsWith("https://"))
                return false;

            return true;
        }

        public IEnumerable<AllGameVm> GetAllGamesVms()
        {
            return Mapper.Instance.Map<IEnumerable<Game>, IEnumerable<AllGameVm>>(Context.Games.Entities);
        }

        public EditGameVm GetEditVm(int id)
        {
            return Mapper.Instance.Map<Game, EditGameVm>(Context.Games.Find(id));
        }

        public void UpdateBindVm(GameBm bind)
        {
            Game originalGame = this.Context.Games.Find(bind.Id);   
            originalGame.Description = bind.Description;
            originalGame.ImageThumbnail = bind.ImageThumbnail;
            originalGame.Price = bind.Price;
            originalGame.Size = bind.Size;
            originalGame.Title = bind.Title;
            originalGame.Trailer = bind.Trailer;
            this.Context.SaveChanges();
        }

        public DeleteGameVm GetDeleteVm(int id)
        {
            return Mapper.Instance.Map<Game, DeleteGameVm>(Context.Games.Find(id));
        }

        public void DeleteGame(DeleteGameBm bind)
        {
            this.Context.Games.Remove(bind.Id);
            this.Context.SaveChanges();
        }
    }
}
