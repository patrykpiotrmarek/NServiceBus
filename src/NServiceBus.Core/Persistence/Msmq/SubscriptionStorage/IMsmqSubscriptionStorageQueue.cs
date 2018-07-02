namespace NServiceBus_6
{
    using System.Collections.Generic;

    interface IMsmqSubscriptionStorageQueue
    {
        IEnumerable<MsmqSubscriptionMessage> GetAllMessages();
        string Send(string body, string label);
        void TryReceiveById(string messageId);
    }
}