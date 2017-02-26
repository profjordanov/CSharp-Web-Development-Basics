using SimpleHttpServer.Models;

namespace SimpleMVC.App.MVC.Interfaces
{
    public interface IHandleable
    {
        HttpResponse Handle(HttpRequest request);
    }
}
