using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicle_Details.Models
{
    public interface ICategoryRepository
    {
      /*  Category GetCategory(int Id);
        IEnumerable<Category> GetAllCategory();*/
        Category Add(Category category);
    }
}
