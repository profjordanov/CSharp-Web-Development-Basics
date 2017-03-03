using AutoMapper;

namespace PizzaForum.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using BindingModels;
    using Models;
    using ViewModels;

    public class ForumService : Service
    {
        public bool IsRegisterModelValid(RegisterUserBindingModel rubm)
        {
            if (rubm.Username.Length < 3)
                return false;

            Regex regex = new Regex("^[a-z0-9]+$");
            if (!regex.IsMatch(rubm.Username))
                return false;

            if (!rubm.Email.Contains("@"))
                return false;

            Regex passRegex = new Regex("^[0-9]{4}$");
            if (!passRegex.IsMatch(rubm.Password))
                return false;

            if (rubm.Password != rubm.ConfirmPassword)         
                return false; 


            if (this.Context.Users.Any(user => user.Username == rubm.Username || user.Email == rubm.Email))
                return false;

            return true;
        }

        public User GetUserFromRegisterBind(RegisterUserBindingModel rubm)
        {
            User user = Mapper.Map<RegisterUserBindingModel, User>(rubm);
            return user;
        }

        public void RegisterUser(User user)
        {
            if (this.Context.Users.Count() != 0)
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
            return this.Context.Users.FirstOrDefault(
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

        internal ProfileVM GetProfileVm(int clickeUserId, int currentUserId)
        {
            ProfileVM profilevm = new ProfileVM()
            {
                ClickeUserId = clickeUserId,
                CurrentUserId = currentUserId,
                ClickedUsername = this.Context.Users.Find(clickeUserId).Username
            };

            IEnumerable<ProfileTopicVM> topics = 
                Mapper.Map<IEnumerable<Topic>, IEnumerable<ProfileTopicVM>>
                (this.Context.Users.Find(clickeUserId).Topics);

            profilevm.Topics = topics;
            return profilevm;
        }
    }
}
