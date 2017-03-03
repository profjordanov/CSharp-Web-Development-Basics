using PizzaForum.ViewModels;

namespace PizzaForum
{
    using System;
    using SimpleHttpServer;
    using SimpleMVC;
    using AutoMapper;
    using Models;
    using BindingModels;

    class Program
    {
        static void Main()
        {
            ConfigureMapper();
            HttpServer server = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server, "PizzaForum");
        }

        private static void ConfigureMapper()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<RegisterUserBindingModel, User>();
                expression.CreateMap<NewCategoryBindingModel, Category>();
                expression.CreateMap<Topic, TopicVM>();
                expression.CreateMap<Topic, DetailTopicVM>();
                expression.CreateMap<Reply, DetailsReplyVM>();
                expression.CreateMap<Topic, ProfileTopicVM>();
            });
        }
    }
}
