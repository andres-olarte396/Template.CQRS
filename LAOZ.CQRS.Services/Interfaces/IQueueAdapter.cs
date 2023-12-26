namespace LAOZ.CQRS.Core.Application.AdapterInterfaces
{
    public interface IQueueAdapter
    {
        Task EnqueueMessage(string queueName, string message);

        Task<string> DequeueMessage(string queueName);

        Task<bool> QueueExists(string queueName);

        Task CreateQueue(string queueName);

        Task DeleteQueue(string queueName);
    }
}
