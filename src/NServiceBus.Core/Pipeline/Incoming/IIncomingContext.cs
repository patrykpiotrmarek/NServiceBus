namespace NServiceBus_6.Pipeline
{
    /// <summary>
    /// The base interface for everything after the transport receive phase.
    /// </summary>
    public interface IIncomingContext : IBehaviorContext, IMessageProcessingContext
    {
    }
}