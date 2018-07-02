namespace NServiceBus_6
{
    using Pipeline;

    interface IForkConnector
    {
    }

    interface IForkConnector<in TFromContext, out TToContext, TForkContext> : IBehavior<TFromContext, TToContext>, IForkConnector
        where TForkContext : IBehaviorContext
        where TFromContext : IBehaviorContext
        where TToContext : IBehaviorContext
    {
    }
}