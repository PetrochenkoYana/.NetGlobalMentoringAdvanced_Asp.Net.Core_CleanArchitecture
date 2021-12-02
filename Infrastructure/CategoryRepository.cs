using System;
using System.Collections.Generic;
using System.Linq;
using Application.Interfaces;
using Domain;

namespace Infrastructure
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationContext _context;
        public CategoryRepository(ApplicationContext context)
        {
            _context = context;
        }
        public IList<Category> GetList()
        {
            return _context.Categories.ToList();
        }

        public Category Get(int categoryId)
        {
            return _context.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
        }

        public Category Add(Category category)
        {
            var categoryAdded = _context.Categories.Add(category).Entity;
            _context.SaveChanges();
            return categoryAdded;
        }

        public Category Update(int id, Category category)
        {
            category.CategoryId = id;
            var categoryUpdated = _context.Categories.Update((category)).Entity;
            _context.SaveChanges();
            return categoryUpdated;
        }

        public void Delete(int categoryId)
        {
            var parentCategories = _context.Categories.Where(c => c.ParentId == categoryId);
            foreach (var category in parentCategories)
            {
                category.ParentId = null;
            }

            _context.Categories.UpdateRange(parentCategories);
            _context.SaveChanges();

            var itemsToDelete = _context.Items.Where(i => i.CategoryId == categoryId);

            _context.Items.RemoveRange(itemsToDelete);

            _context.SaveChanges();
            var objectCategory = _context.Categories.Remove(_context.Categories.FirstOrDefault(c => c.CategoryId == categoryId));
            if (objectCategory != null)
            {
                _context.SaveChanges();
            }

            _context.SaveChanges();
        }
    }
}
