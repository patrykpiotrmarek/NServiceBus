namespace NServiceBus_6
{
    using System.Threading.Tasks;
    using Transport;

    interface IPipelineExecutor
    {
        Task Invoke(MessageContext messageContext);
    }
}