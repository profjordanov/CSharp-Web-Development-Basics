using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PizzaForum.BindingModels;
using PizzaForum.Models;
using PizzaForum.ViewModels;

namespace PizzaForum.Services
{
    class TopicsService : Service
    {
        public IEnumerable<string> GetCategoryNames()
        {
            return this.Context.Categories.Entities.Select(ct => ct.Name);
        }

        internal void AddNewTopic(NewTopicBindingModel bind, User user)
        {
            Category category = this.Context.Categories.FirstOrDefault(cat => cat.Name == bind.Category);

            Topic topic = new Topic()
            {
                Author = user,
                Title = bind.Title,
                Content = bind.Content,
                PublishDate = DateTime.Now,
                Category = category
            };

            this.Context.Topics.Add(topic);
            this.Context.SaveChanges();
        }

        internal bool IsNewTopicValid(NewTopicBindingModel bind)
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

        internal DetailsVM GetDetailsVm(int id)
        {
            Topic topic = this.Context.Topics.Find(id);
            DetailTopicVM topicVm = Mapper.Map<Topic, DetailTopicVM>(topic);

            IEnumerable<DetailsReplyVM> replies = Mapper.Map<IEnumerable<Reply>, IEnumerable<DetailsReplyVM>>(topic.Replies);

            return new DetailsVM
            {
                Replies = replies,
                Topic = topicVm
            };
        }

        internal void AddNewReply(DetailsReplyBM bind, User user)
        {
            Topic topic = this.Context.Topics.FirstOrDefault(tp => tp.Title == bind.TopicTitle);
            this.Context.Replies.Add(new Reply
            {
                PublishDate = DateTime.Now,
                ImageUrl = bind.ImageUrl,
                Author = user,
                Content = bind.Content,
                Topic = topic
            });
            this.Context.SaveChanges();
        }
    }
}
