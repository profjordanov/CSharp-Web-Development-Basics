using System.Linq;
using System.Text.RegularExpressions;
using PizzaForum.BindingModels;
using PizzaForum.Models;

namespace PizzaForum.Services
{
    public class ForumService : Service
    {
        public bool IsRegisterModelValid(RegisterUserBindingModel rubm)
        {
            if (rubm.Username.Length < 3)
            {
                return false;
            }
            Regex regex = new Regex("^[a-z0-9]+$");
            if (!regex.IsMatch(rubm.Username))
            {
                return false;
            }
            if (!rubm.Email.Contains("@"))
            {
                return false;
            }

            Regex passRegex = new Regex("^[0-9]{4}$");
            if (!passRegex.IsMatch(rubm.Password) || rubm.Password != rubm.ConfirmPassword)
            {
                return false;
            }

            if (this.Context.Users.Any(user => user.Username == rubm.Username || user.Email == rubm.Email))
            {
                return false;
            }

            return true;
        }

        public User GetUserFromRegisterBind(RegisterUserBindingModel rubm)
        {
            return new User()
            {
                Username = rubm.Username,
                Password = rubm.Password,
                Email = rubm.Email
            };
            
        }

        public void RegisterUser(User user)
        {
            if (!this.Context.Users.Any())
            {
                user.IsAdmin = true;
            }
            this.Context.Users.Add(user);
            this.Context.SaveChanges();
        }

        public bool IsLoginModelValid(LoginUserBindingModel lubm)
        {
            return this.Context.Users.Any(
                user =>
                    (user.Username == lubm.Credential || user.Email == lubm.Credential) &&
                    user.Password == lubm.Password);
        }

        public User GetUserFromLoginBind(LoginUserBindingModel lubm)
        {
            return this.Context.Users.First(
               user =>
                   (user.Username == lubm.Credential || user.Email == lubm.Credential) &&
                   user.Password == lubm.Password);
        }

        public void LoginUser(User user, string sessionId)
        {
            this.Context.Logins.Add(new Login()
            {
                SessionId = sessionId,
                User = user,
                IsActive = true
            });
            this.Context.SaveChanges();
        }
    }
}