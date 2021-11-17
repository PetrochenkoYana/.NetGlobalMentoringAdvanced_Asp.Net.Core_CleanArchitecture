using System;
using System.Collections.Generic;
using Application.Interfaces;
using Domain;

namespace Application.UseCases
{
    public class CategoryUseCases : ICategoryUseCases
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryUseCases(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IList<Category> GetList()
        {
            return _categoryRepository.GetList();
        }

        public Category Get(int categoryId)
        {
            return _categoryRepository.Get(categoryId);
        }

        public Category Add(Category category)
        {
            return _categoryRepository.Add(category);
        }

        public Category Update(int id, Category category)
        {
            return _categoryRepository.Update(id, category);
        }

        public bool Delete(int categoryId)
        {
            return _categoryRepository.Delete(categoryId);
        }
    }
}
