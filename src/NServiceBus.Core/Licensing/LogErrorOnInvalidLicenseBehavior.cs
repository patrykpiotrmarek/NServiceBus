namespace NServiceBus_6
{
    using System;
    using System.Threading.Tasks;
    using Logging;
    using Pipeline;

    class LogErrorOnInvalidLicenseBehavior : IBehavior<IIncomingPhysicalMessageContext, IIncomingPhysicalMessageContext>
    {
        public Task Invoke(IIncomingPhysicalMessageContext context, Func<IIncomingPhysicalMessageContext, Task> next)
        {
            Log.Error("Your license has expired");

            return next(context);
        }

        static ILog Log = LogManager.GetLogger<LogErrorOnInvalidLicenseBehavior>();
    }
}