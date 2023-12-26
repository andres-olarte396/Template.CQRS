using LAOZ.CQRS.Core.Application.AdapterInterfaces;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage;

namespace LAOZ.CQRS.Infrastructure.Adapters
{
    public class AzureQueueAdapter : IQueueAdapter
    {
        private readonly CloudQueueClient queueClient;

        public AzureQueueAdapter(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            CloudStorageAccount storageAccount;
            if (CloudStorageAccount.TryParse(connectionString, out storageAccount))
            {
                queueClient = storageAccount.CreateCloudQueueClient();
            }
            else
            {
                throw new ArgumentException("Invalid storage account connection string");
            }
        }

        public Task EnqueueMessage(string queueName, string message)
        {
            var queue = GetQueueReference(queueName);
            return queue.AddMessageAsync(new CloudQueueMessage(message));
        }

        public async Task<string> DequeueMessage(string queueName)
        {
            var queue = GetQueueReference(queueName);
            Task<CloudQueueMessage> message = queue.GetMessageAsync();

            if (message != null)
            {
                await queue.DeleteMessageAsync(message.Result);
                return message.Result.ToString();
            }

            return null;
        }

        public async Task<bool> QueueExists(string queueName)
        {
            var queue = GetQueueReference(queueName);
            return await queue.ExistsAsync();
        }

        public async Task CreateQueue(string queueName)
        {
            var queue = GetQueueReference(queueName);
            await queue.CreateIfNotExistsAsync();
        }

        public async Task DeleteQueue(string queueName)
        {
            var queue = GetQueueReference(queueName);
            await queue.DeleteIfExistsAsync();
        }

        private CloudQueue GetQueueReference(string queueName)
        {
            return queueClient.GetQueueReference(queueName);
        }
    }

}
