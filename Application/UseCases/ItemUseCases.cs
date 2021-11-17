using System.Collections.Generic;
using Application.Interfaces;
using Domain;
using Domain.Models;

namespace Application.UseCases
{
    public class ItemUseCases : IItemUseCases
    {
        private readonly IItemRepository _itemRepository;

        public ItemUseCases(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public IList<Item> GetList(ItemsRequest request)
        {
            return _itemRepository.GetList(request);
        }

        public Item Get(int itemId)
        {
            return _itemRepository.Get(itemId);
        }

        public Item Add(Item item)
        {
            return _itemRepository.Add(item);
        }

        public Item Update(int id, Item item)
        {
            return _itemRepository.Update(id, item);
        }

        public bool Delete(int itemId)
        {
            return _itemRepository.Delete(itemId);
        }
    }
}
