using System.Collections.Generic;
using System.Linq;
using PizzaForum.BindingModels;
using PizzaForum.Models;
using PizzaForum.ViewModels;
using SimpleHttpServer.Models;

namespace PizzaForum.Services
{
    public class CategoriesService : Service
    {
        public AllViewModel GetAllViewModel(User activeUser)
        {
            AllViewModel view = new AllViewModel();

            IEnumerable<AllCategoryViewModel> categories = this.Context.Categories.Select(category => new AllCategoryViewModel()
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
            this.Context.Categories.Add(new Category()
            {
                Name = bind.Name
            });
            this.Context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            this.Context.Categories.Remove(this.Context.Categories.Find(id));
            this.Context.SaveChanges();
        }

        public EditCategoryViewModel GetEditCategoryVM(int categoryId)
        {
            Category category = Context.Categories.Find(categoryId);
           return  new EditCategoryViewModel()
           {
               CategoryName = category.Name,
               Id = categoryId
           };
        }

        public void EditCategoryEntity(EditCategoryBM bind)
        {
            Category category = Context.Categories.Find(bind.CategoryId);
            if (category != null)
            {
                category.Name = bind.CategoryName;
            }

            Context.SaveChanges();
        }
    }
}