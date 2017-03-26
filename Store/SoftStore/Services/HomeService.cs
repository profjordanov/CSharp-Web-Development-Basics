using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using SoftStore.BindingModels;
using SoftStore.Models;
using SoftStore.Services.Contracts;
using SoftStore.ViewModels;

namespace SoftStore.Services
{
    public class HomeService : Service, IHomeService
    {
        public IEnumerable<HomeGameVm> GetHomeVms(string filter, User user)
        {
            if (string.IsNullOrEmpty(filter) || filter == "all")
            {
                IEnumerable<Game> games = Context.Games.Entities;
                IEnumerable<HomeGameVm> vms = Mapper.Instance.Map<IEnumerable<Game>, IEnumerable<HomeGameVm>>(games);
                return vms;
            }
            else
            {
                IEnumerable<Game> games = user.Games;
                IEnumerable<HomeGameVm> vms = Mapper.Instance.Map<IEnumerable<Game>, IEnumerable<HomeGameVm>>(games);
                return vms;
            }
        }

        public DetailsGameVm GetDetailedGameVm(int id)
        {
            return Mapper.Instance.Map<Game, DetailsGameVm>(Context.Games.Find(id));
        }

        public void BuyGameForUser(User currentUser, BuyGameBm bind)
        {
            currentUser.Games.Add(Context.Games.Find(bind.Id));
            this.Context.SaveChanges();

        }
    }
}
