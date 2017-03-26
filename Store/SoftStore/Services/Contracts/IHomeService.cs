using System.Collections.Generic;
using SoftStore.BindingModels;
using SoftStore.Models;
using SoftStore.ViewModels;

namespace SoftStore.Services.Contracts
{
    public interface IHomeService
    {
        IEnumerable<HomeGameVm> GetHomeVms(string filter, User user);
        DetailsGameVm GetDetailedGameVm(int id);
        void BuyGameForUser(User currentUser, BuyGameBm bind);
    }
}
