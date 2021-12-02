using System.Collections.Generic;
using System.Linq;
using Application.Interfaces;
using Domain;
using Domain.Models;
using Microsoft.Extensions.Configuration;

namespace Infrastructure
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationContext _context;
        public ItemRepository(ApplicationContext context)
        {
            _context = context;
        }
        public IList<Item> GetList(ItemsRequest request)
        {
            var items = _context.Items.ToList();

            if (request.CategoryId != null)
                items = items.Where(i => i.CategoryId == request.CategoryId).ToList();

            if (request.Size != null)
                items = items.GetRange(request.StartAt, request.Size.Value);
            else
                items = items.GetRange(request.StartAt, items.Count);

            return items;
        }

        public Item Get(int itemId)
        {
            return _context.Items.First(i => i.ItemId == itemId);

        }

        public void Delete(int itemId)
        {
            var deleted = _context.Items.Remove(_context.Items.First(i => i.ItemId == itemId));
            if (deleted != null)
            {
                _context.SaveChanges();
            }
        }

        public Item Update(int id, Item item)
        {
            item.ItemId = id;
            var itemUpdate = _context.Items.Update(item).Entity;
            _context.SaveChanges();
            return itemUpdate;
        }

        public Item Add(Item item)
        {
            var itemAdd = _context.Items.Add(item).Entity;
            _context.SaveChanges();
            return itemAdd;
        }
    }
}
