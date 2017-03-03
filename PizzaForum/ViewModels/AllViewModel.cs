namespace PizzaForum.ViewModels
{
    using System.Collections.Generic;
    using System.Text;

    public class AllViewModel
    {
        public IEnumerable<AllCategoryViewModel> Categories { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (AllCategoryViewModel allCategoryViewModel in this.Categories)
            {
                builder.Append(allCategoryViewModel);
            }

            return builder.ToString();
        }
    }
}
