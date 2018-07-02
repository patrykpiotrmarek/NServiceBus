namespace NServiceBus_6.Pipeline
{
    /// <summary>
    /// Pipeline context for publish operations.
    /// </summary>
    public interface IOutgoingPublishContext : IOutgoingContext
    {
        /// <summary>
        /// The message to be published.
        /// </summary>
        OutgoingLogicalMessage Message { get; }
    }
}