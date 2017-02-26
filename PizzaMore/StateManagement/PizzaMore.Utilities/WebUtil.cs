using PizzaMore.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace PizzaMore.Utilities
{
    public static class WebUtil
    {
        public static bool IsPost()
        {
            string requestMethod = Environment.GetEnvironmentVariable("REQUEST_METHOD").ToLower();
            if (requestMethod == "post")
            {
                return true;
            }
            return false;
        }

        public static bool IsGet()
        {
            string requestMethod = Environment.GetEnvironmentVariable("REQUEST_METHOD").ToLower();
            if (requestMethod == "get")
            {
                return true;
            }
            return false;
        }

        public static IDictionary<string, string> RetrieveGetParameters()
        {
            string parametersString = WebUtility.UrlDecode(Environment.GetEnvironmentVariable("QUERY_STRING"));

            return RetrieveRequestParameters(parametersString);
        }

        public static IDictionary<string, string> RetrievePostParameters()
        {
            string parametersString = WebUtility.UrlDecode(Console.ReadLine());

            return RetrieveRequestParameters(parametersString);
        }

        private static IDictionary<string, string> RetrieveRequestParameters(string parametersString)
        {
            Dictionary<string, string> resultParameters = new Dictionary<string, string>();
            var parameters = parametersString.Split('&');
            foreach (var param in parameters)
            {
                var pair = param.Split('=');
                var name = pair[0];
                string value = null;
                if (pair.Length > 1)
                {
                    value = pair[1];
                }

                resultParameters.Add(name, value);
            }

            return resultParameters;
        }

        public static ICookieCollection GetCookies()
        {
            string cookieString = Environment.GetEnvironmentVariable("HTTP_COOKIE");
            if (string.IsNullOrEmpty(cookieString))
            {
                return new CookieCollection();
            }

            var cookies = new CookieCollection();
            string[] cookieSaves = cookieString.Split(';');
            foreach (var cookieSave in cookieSaves)
            {
                string[] cookiePair = cookieSave.Split('=').Select(x => x.Trim()).ToArray();
                var cookie = new Cookie(cookiePair[0], cookiePair[1]);
                cookies.AddCookie(cookie);
            }
            return cookies;
        }

        public static Session GetSession()
        {
            var cookies = GetCookies();
            if (!cookies.ContainsKey("sid"))
            {
                return null;
            }

            var sessionCookie = cookies["sid"];
            var ctx = new PizzaMoreContext();

            var session = ctx.Sessions
                .FirstOrDefault(s => s.Id == sessionCookie.Value);
            return session;
        }

        public static void PageNotAllowed()
        {
            PrintFileContent("../../htdocs/pm/game/index.html");
        }

        public static void PrintFileContent(string path)
        {
            string content = File.ReadAllText(path);
            Console.WriteLine(content);
        }
    }
}
