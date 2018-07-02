namespace NServiceBus_6
{
    using System.Threading.Tasks;

    interface IEventAggregator
    {
        Task Raise<T>(T @event);
    }
}