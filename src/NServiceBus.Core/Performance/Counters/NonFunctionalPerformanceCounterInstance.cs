namespace NServiceBus_6
{
    class NonFunctionalPerformanceCounterInstance : IPerformanceCounterInstance
    {
        public void Increment()
        {
            //NOOP
        }

        public void Dispose()
        {
            //NOOP
        }
    }
}