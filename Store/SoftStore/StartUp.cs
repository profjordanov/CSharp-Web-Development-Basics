using AutoMapper;
using SimpleHttpServer;
using SimpleMVC;
using SoftStore.BindingModels;
using SoftStore.Models;
using SoftStore.ViewModels;

namespace SoftStore
{
    class StartUp
    {
        static void Main()
        {
            ConfigureMapper();
            HttpServer server = new HttpServer(8081, RoutesTable.Routes);
            MvcEngine.Run(server, "SoftStore");
        }

        private static void ConfigureMapper()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<RegisterUserBm, User>();
                expression.CreateMap<GameBm, Game>();
                expression.CreateMap<Game, AllGameVm>();
                expression.CreateMap<Game, EditGameVm>();
                expression.CreateMap<Game, DeleteGameVm>();
                expression.CreateMap<Game, HomeGameVm>();
                expression.CreateMap<Game, DetailsGameVm>();
            });
        }
    }
}
