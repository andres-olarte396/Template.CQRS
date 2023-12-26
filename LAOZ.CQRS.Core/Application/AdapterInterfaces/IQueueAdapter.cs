namespace LAOZ.CQRS.Core.Application.AdapterInterfaces
{
    public interface IQueueAdapter
    {
        void EnqueueMessage(string queueName, string message);

        string DequeueMessage(string queueName);

        bool QueueExists(string queueName);

        void CreateQueue(string queueName);

        void DeleteQueue(string queueName);
    }
}
