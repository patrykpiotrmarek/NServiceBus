namespace NServiceBus_6
{
    using Pipeline;

    interface IPipelineCache
    {
        IPipeline<TContext> Pipeline<TContext>()
            where TContext : IBehaviorContext;
    }
}