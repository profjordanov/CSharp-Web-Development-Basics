using System.Collections.Generic;
using System.Linq;
using PizzaForum.ViewModels;

namespace PizzaForum.Services
{
    public class HomeService : Service
    {
        public IEnumerable<TopicVM> GetTopTenLatestTopics()
        {
            IEnumerable<TopicVM> topics =
                Context.Topics.OrderByDescending(model => model.PublishDate).Take(10).Select(vm => new TopicVM()
                {
                    Id = vm.Id,
                    CategoryName = vm.Category.Name,
                    AuthorName = vm.Author.Username,
                    Date = vm.PublishDate,
                    RepliesCount = vm.Replies.Count,
                    TopicTitle = vm.Title
                });
            return topics;
        }
       
    }
}