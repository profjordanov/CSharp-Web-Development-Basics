using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleHttpServer;
using SimpleMVC;

namespace PizzaForum
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpServer server = new HttpServer(8081, RoutesTable.Routes);
            MvcEngine.Run(server, "PizzaForum");
        }
    }
}
