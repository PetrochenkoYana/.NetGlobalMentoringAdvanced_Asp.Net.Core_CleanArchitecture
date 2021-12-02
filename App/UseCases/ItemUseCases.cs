using System.Collections.Generic;
using Application.Interfaces;
using Application.ServiceBus;
using Domain;
using Domain.Models;
using Microsoft.Extensions.Configuration;

namespace Application.UseCases
{
    public class ItemUseCases : IItemUseCases
    {
        private readonly string _topicName;
        private readonly IItemRepository _itemRepository;
        private readonly IServiceBusManager _serviceBusManager;


        public ItemUseCases(IItemRepository itemRepository, IServiceBusManager serviceBusManager, IConfiguration configuration)
        {
            _itemRepository = itemRepository;
            _serviceBusManager = serviceBusManager;
            _topicName = configuration["ServiceBus.Topic.ItemUpdate"];
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
            var updated = _itemRepository.Update(id, item);
            _serviceBusManager.SendToTopicAsync(_topicName, updated);
            return updated;
        }

        public void Delete(int itemId)
        {
            _itemRepository.Delete(itemId);
        }
    }
}
