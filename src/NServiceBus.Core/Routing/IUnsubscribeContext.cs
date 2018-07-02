namespace NServiceBus_6.Pipeline
{
    using System;

    /// <summary>
    /// Provides context for unsubscribe requests.
    /// </summary>
    public interface IUnsubscribeContext : IBehaviorContext
    {
        /// <summary>
        /// The type of the event.
        /// </summary>
        Type EventType { get; }
    }
}