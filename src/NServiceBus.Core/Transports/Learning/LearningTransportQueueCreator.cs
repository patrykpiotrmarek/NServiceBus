namespace NServiceBus_6
{
    using System.Threading.Tasks;
    using Transport;

    class LearningTransportQueueCreator : ICreateQueues
    {
        public Task CreateQueueIfNecessary(QueueBindings queueBindings, string identity) => TaskEx.CompletedTask;
    }
}