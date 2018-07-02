namespace NServiceBus_6.AcceptanceTests.Core.FakeTransport
{
    using System;
    using System.Threading.Tasks;
    using Transport;

    class FakeReceiver : IPushMessages
    {
        public FakeReceiver(bool throwCritical, bool throwOnStop, Exception exceptionToThrow)
        {
            this.throwCritical = throwCritical;
            this.throwOnStop = throwOnStop;
            this.exceptionToThrow = exceptionToThrow;
        }

        public Task Init(Func<MessageContext, Task> onMessage, Func<ErrorContext, Task<ErrorHandleResult>> onError, NServiceBus_6.CriticalError criticalError, PushSettings settings)
        {
            this.criticalError = criticalError;
            return Task.FromResult(0);
        }

        public void Start(PushRuntimeSettings limitations)
        {
            if (throwCritical)
            {
                criticalError.Raise(exceptionToThrow.Message, exceptionToThrow);
            }
        }

        public async Task Stop()
        {
            await Task.Yield();

            if (throwOnStop)
            {
                throw exceptionToThrow;
            }
        }

        NServiceBus_6.CriticalError criticalError;
        bool throwCritical;
        readonly bool throwOnStop;
        readonly Exception exceptionToThrow;
    }
}