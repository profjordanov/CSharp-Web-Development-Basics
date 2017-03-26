using System.Collections.Generic;
using SoftStore.BindingModels;
using SoftStore.ViewModels;

namespace SoftStore.Services.Contracts
{
    public interface IAdminService
    {
        void AddGame(GameBm bind);
        bool IsGameValid(GameBm bind);
        IEnumerable<AllGameVm> GetAllGamesVms();
        EditGameVm GetEditVm(int id);
        void UpdateBindVm(GameBm bind);
        DeleteGameVm GetDeleteVm(int id);
        void DeleteGame(DeleteGameBm bind);
    }
}
