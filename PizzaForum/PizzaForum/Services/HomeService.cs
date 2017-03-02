using System.Collections.Generic;
using PizzaForum.ViewModels;
using System.Linq;
using AutoMapper;
using PizzaForum.Models;

namespace PizzaForum.Services
{
    public class HomeService : Service
    {
        internal IEnumerable<TopicVM> GetTopTenLatestTopics()
        {
            IEnumerable<Topic> topics =
                this.Context.Topics.Entities.OrderByDescending(model => model.PublishDate).Take(10);

            IEnumerable<TopicVM> topicsVms = Mapper.Map<IEnumerable<Topic>, IEnumerable<TopicVM>>(topics);

            return topicsVms;
        }

        internal IEnumerable<string> GetCategoriesNames()
        {
            return this.Context.Categories.Entities.Select(x => x.Name);
        }
    }
}
