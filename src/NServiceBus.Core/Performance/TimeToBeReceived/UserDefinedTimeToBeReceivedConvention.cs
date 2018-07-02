namespace NServiceBus_6
{
    using System;

    class UserDefinedTimeToBeReceivedConvention
    {
        public UserDefinedTimeToBeReceivedConvention(Func<Type, TimeSpan> retrieveTimeToBeReceived)
        {
            GetTimeToBeReceivedForMessage = retrieveTimeToBeReceived;
        }

        public Func<Type, TimeSpan> GetTimeToBeReceivedForMessage { get; private set; }
    }
}