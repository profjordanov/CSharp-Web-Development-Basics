using System.Collections.Generic;
using System.Text;

namespace PizzaForum.ViewModels
{
    public class AllViewModel
    {
        public IEnumerable<AllCategoryViewModel> Categories { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (AllCategoryViewModel allCategoryViewModel in Categories)
            {
                builder.Append(allCategoryViewModel);
            }

            return builder.ToString();
        }
    }
}