namespace NServiceBus_6
{
    using ObjectBuilder;

    class RootContext : BehaviorContext
    {
        public RootContext(IBuilder builder, IPipelineCache pipelineCache, IEventAggregator eventAggregator) : base(null)
        {
            Set(builder);
            Set(pipelineCache);
            Set(eventAggregator);
        }
    }
}