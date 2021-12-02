using System.Collections.Generic;
using Domain;
using Domain.Models;

namespace Application.Interfaces
{
    public interface IItemUseCases
    {
        IList<Item> GetList(ItemsRequest request);
        Item Get(int itemId);
        Item Add(Item item);
        Item Update(int id , Item item);
        void Delete(int itemId);
    }
}
