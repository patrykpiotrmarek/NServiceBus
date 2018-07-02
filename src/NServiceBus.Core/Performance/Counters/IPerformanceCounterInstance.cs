namespace NServiceBus_6
{
    using System;

    interface IPerformanceCounterInstance : IDisposable
    {
        void Increment();
    }
}