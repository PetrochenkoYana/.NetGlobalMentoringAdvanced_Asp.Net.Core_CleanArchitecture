using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.ServiceBus
{
    public class ServiceBusManager : IServiceBusManager
    {
        private const string ServiceBusConnectionString = "App.ServiceBus";

        // the client that owns the connection and can be used to create senders and receivers
        private readonly ServiceBusClient client;

        public ServiceBusManager(IConfiguration configuration)
        {
            var connection = configuration[ServiceBusConnectionString];
            // The Service Bus client types are safe to cache and use as a singleton for the lifetime
            // of the application, which is best practice when messages are being published or read
            // regularly.
            //
            // Create the clients that we'll use for sending and processing messages.
            client = new ServiceBusClient(connection);
        }

        public Task SendToQueue<T>(string queueName, T request)
        {
            throw new System.NotImplementedException();
        }

        public async Task SendToTopicAsync<T>(string topicName, T request)
        {
            ServiceBusSender sender = client.CreateSender(topicName);

            // create a batch 
            ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();

            string messageBody = JsonSerializer.Serialize(request);
            // try adding a message to the batch
            if (!messageBatch.TryAddMessage(new ServiceBusMessage(messageBody)))
            {
                // if it is too large for the batch
                throw new Exception($"The message {request} is too large to fit in the batch.");
            }

            try
            {
                // Use the producer client to send the batch of messages to the Service Bus queue
                await sender.SendMessagesAsync(messageBatch);
            }
            finally
            {
                // Calling DisposeAsync on client types is required to ensure that network
                // resources and other unmanaged objects are properly cleaned up.
                await sender.DisposeAsync();
            }
        }
    }
}
