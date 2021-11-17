using System.Collections.Generic;
using Domain;
using Domain.Models;

namespace Application.Interfaces
{
    public interface IItemRepository
    {
        IList<Item> GetList(ItemsRequest request);
        Item Get(int itemId);
        Item Add(Item item);
        Item Update(int id, Item item);
        bool Delete(int itemId);
    }
}
