namespace NServiceBus_6
{
    using Settings;
    using Transport;

    class OutboundTransport
    {
        public TransportSendInfrastructure Configure(ReadOnlySettings settings)
        {
            var transportInfrastructure = settings.Get<TransportInfrastructure>();
            return transportInfrastructure.ConfigureSendInfrastructure();
        }
    }
}