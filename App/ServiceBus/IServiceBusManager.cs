using System.Threading.Tasks;

namespace Application.ServiceBus
{
    public interface IServiceBusManager
    {
        Task SendToQueue<T>(string queueName, T request);

        Task SendToTopicAsync<T>(string topicName, T request);
    }
}
