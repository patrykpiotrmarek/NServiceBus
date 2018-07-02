namespace NServiceBus_6
{
    using Transport;

    class MessageFaulted : MessageProcessingFailed
    {
        public string ErrorQueue { get; }

        public MessageFaulted(ErrorContext errorContext, string errorQueue) : base(errorContext)
        {
            ErrorQueue = errorQueue;
        }
    }
}