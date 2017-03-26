using System.Text.RegularExpressions;
using AutoMapper;
using SoftStore.BindingModels;
using SoftStore.Models;
using SoftStore.Services.Contracts;

namespace SoftStore.Services
{
    public class UsersService : Service, IUsersService
    {
        public bool IsBindModelValid(RegisterUserBm bind)
        {
            if (!bind.Email.Contains("@"))
                return false;

            if (!bind.Email.Contains("."))
                return false;

            Regex passRegex = new Regex("[a-zA-Z0-9]{6,}");
            if (!passRegex.IsMatch(bind.Password))
                return false;

            if (bind.Password != bind.ConfirmPassword)
                return false;

            if (string.IsNullOrEmpty(bind.FullName))
                return false;

            if (this.Context.Users.Any(user => user.Email == bind.Email))
                return false;

            return true;
        }

        public void RegisterUser(RegisterUserBm bind)
        {
            User user = Mapper.Instance.Map<RegisterUserBm, User>(bind);

            if (this.Context.Users.Count() == 0)
            {
                user.IsAdmin = true;
            }

            this.Context.Users.Add(user);
            this.Context.SaveChanges();

        }

        public bool IsLoginSuccessful(LoginUserBm bind, string sessionId)
        {
            User wantedUser = this.Context.Users.FirstOrDefault(user => user.Email == bind.Email && user.Password == bind.Password);
            if (wantedUser == null)
            {
                return false;
            }

            Login currentLogin = new Login()
            {
                User = wantedUser,
                IsActive = true,
                SessionId = sessionId
            };

            this.Context.Logins.Add(currentLogin);
            this.Context.SaveChanges();
            return true;
        }

        
    }
}
