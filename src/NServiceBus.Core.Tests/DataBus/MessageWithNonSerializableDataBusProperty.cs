namespace NServiceBus_6.Core.Tests.DataBus
{
    public class MessageWithNonSerializableDataBusProperty : IMessage
    {
        public NonSerializable PropertyDataBus { get; set; }
    }

    public class NonSerializable
    {

    }
}