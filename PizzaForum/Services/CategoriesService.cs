using AutoMapper;

namespace PizzaForum.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using BindingModels;
    using Models;
    using ViewModels;

    public class CategoriesService : Service
    {
        public AllViewModel GetAllViewModel(User activeUser)
        {
            AllViewModel view = new AllViewModel();

            IEnumerable<AllCategoryViewModel> categories = this.Context.Categories.Entities
                                        .Select(category => new AllCategoryViewModel()
                                        {
                                            Id = category.Id,
                                            CategoryName = category.Name
                                        });

            view.Categories = categories;

            return view;
        }

        public bool IsNewCategoryValid(NewCategoryBindingModel bind)
        {
            if (!string.IsNullOrEmpty(bind.Name))
            {
                return false;
            }

            return true;
        }

        public void AddNewCategory(NewCategoryBindingModel bind)
        {
            Category category = Mapper.Map<NewCategoryBindingModel, Category>(bind);
            this.Context.Categories.Add(category);
            this.Context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            this.Context.Categories.Remove(this.Context.Categories.Find(id));
            this.Context.SaveChanges();
        }

        internal EditCategoryViewModel GetEditCategoryVM(int categoryId)
        {
            Category category = this.Context.Categories.Find(categoryId);
            return new EditCategoryViewModel()
            {
                CategoryName = category.Name,
                Id = categoryId
            };
        }

        internal void EditCategoryEntity(EditCategoryBM bind)
        {
            Category category = this.Context.Categories.Find(bind.CategoryId);
            if (category != null)
            {
                category.Name = bind.CategoryName;
            }

            this.Context.SaveChanges();
        }

        internal IEnumerable<TopicVM> GetCategoryTopicsVms(string categoryName)
        {
            return
                Mapper.Map<IEnumerable<Topic>, IEnumerable<TopicVM>>(
                    this.Context.Categories.FirstOrDefault(ct => ct.Name == categoryName).Topics);
        }
    }
}
