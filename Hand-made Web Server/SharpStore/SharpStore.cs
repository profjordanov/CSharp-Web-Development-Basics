using SimpleHttpServer.Models;
using System.Collections.Generic;
using System.IO;

namespace SharpStore
{
    class SharpStore
    {
        static void Main(string[] args)
        {
            var routes = new List<Route>()
            {
                new Route()
                {
                    Name = "Home Directory",
                    Method = SimpleHttpServer.Enums.RequestMethod.GET,
                    UrlRegex = "^/home$",
                    Callable = (request) =>
                    {
                        return new HttpResponse()
                        {
                            StatusCode = SimpleHttpServer.Enums.ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText("../../content/home.html")
                        };
                    }
                },
                new Route()
                {
                    Name = "Carousel CSS",
                    Method = SimpleHttpServer.Enums.RequestMethod.GET,
                    UrlRegex = "^/content/css/carousel.css$",
                    Callable = (request) =>
                    {
                        var response = new HttpResponse()
                        {
                            StatusCode = SimpleHttpServer.Enums.ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText("../../content/css/carousel.css")
                        };
                        response.Header.ContentType = "text/css";
                        return response;
                    }
                },
                new Route()
                {
                    Name = "Bootstrap JS",
                    Method = SimpleHttpServer.Enums.RequestMethod.GET,
                    UrlRegex = "^/bootstrap/js/bootstrap.min.js$",
                    Callable = (request) =>
                    {
                        var response = new HttpResponse()
                        {
                            StatusCode = SimpleHttpServer.Enums.ResponseStatusCode.Ok,
                            ContentAsUTF8 = File.ReadAllText("../../content/bootstrap/js/bootstrap.min.js")
                        };
                        response.Header.ContentType = "application/x-javascript";
                        return response;
                    }
                },
                //TODO Add route for bootstrap.min.css
            };

            //TODO: Create new HTTP Server and run it
        }
    }
}