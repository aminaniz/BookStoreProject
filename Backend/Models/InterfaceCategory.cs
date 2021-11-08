using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Models
{
    interface InterfaceCategory
    {
        List<Category> GetCategories();
        List<Category> Search(string searchword);
        int UpdateCategory(Category category);
        int DeleteCategory(int id);
        int AddCategory(Category category);
    }
}
