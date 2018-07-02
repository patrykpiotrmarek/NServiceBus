namespace NServiceBus_6
{
    using Settings;
    using Transport;

    class InboundTransport
    {
        public TransportReceiveInfrastructure Configure(ReadOnlySettings settings)
        {
            var transportInfrastructure = settings.Get<TransportInfrastructure>();
            return transportInfrastructure.ConfigureReceiveInfrastructure();
        }
    }
}