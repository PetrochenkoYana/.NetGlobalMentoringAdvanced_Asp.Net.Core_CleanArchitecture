using System.Collections.Generic;
using Domain;

namespace Application.Interfaces
{
    public interface ICategoryRepository
    {
        IList<Category> GetList();
        Category Get(int categoryId);
        Category Add(Category category);
        Category Update(int id, Category category);
        bool Delete(int categoryId);
    }
}
