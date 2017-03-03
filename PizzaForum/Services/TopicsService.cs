using System;
using System.Collections.Generic;
using System.Linq;
using PizzaForum.BindingModels;
using PizzaForum.Models;
using PizzaForum.ViewModels;

namespace PizzaForum.Services
{
    public class TopicsService : Service
    {
        public IEnumerable<string> GetCategoryNames()
        {
            return Context.Categories.Select(ct => ct.Name);
        }

        public void AddNewTopic(NewTopicBindingModel bind, User user)
        {
            Category category = Context.Categories.FirstOrDefault(cat => cat.Name == bind.Category);
            Topic topic = new Topic()
            {
                Author = user,
                Title = bind.Title,
                Content = bind.Content,
                PublishDate = DateTime.Now,
                Category = category
            };

            Context.Topics.Add(topic);
            Context.SaveChanges();
        }

        public bool IsNewTopicValid(NewTopicBindingModel bind)
        {
            if (bind.Title.Length > 30)
            {
                return false;
            }

            if (bind.Content.Length > 5000)
            {
                return false;
            }

            return true;
        }

        public DetailsVM GetDetailsVm(int id)
        {
            Topic topic = Context.Topics.Find(id);
            DetailTopicVM topicVm = new DetailTopicVM()
            {
                Title = topic.Title,
                AuthorName = topic.Author.Username,
                Content = topic.Content,
                PublicDate = topic.PublishDate
            };

            IEnumerable<DetailsReplyVM> replies = topic.Replies.Select(repl => new DetailsReplyVM()
            {
                AuthorName = repl.Author.Username,
                Content = repl.Content,
                ImageUrl = repl.ImageUrl,
                PublishDate = repl.PublishDate
            });

            return new DetailsVM
            {
                Replies = replies,
                Topic = topicVm
            };
        }

        public void AddNewReply(DetailsReplyBM bind, User user)
        {
            Topic topic = Context.Topics.FirstOrDefault(tp => tp.Title == bind.TopicTitle);
            Context.Replies.Add(new Replies()
            {
                PublishDate = DateTime.Now,
                ImageUrl = bind.ImageUrl,
                Author = user,
                Content = bind.Content,
                Topic = topic
            });
            Context.SaveChanges();
        }
    }
}