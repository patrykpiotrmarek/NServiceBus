namespace NServiceBus_6.AcceptanceTesting.Support
{
    using System;
    using System.Threading.Tasks;

    public class WhenDefinition<TContext> : IWhenDefinition where TContext : ScenarioContext
    {
        public WhenDefinition(Predicate<TContext> condition, Func<IMessageSession, Task> action)
        {
            Id = Guid.NewGuid();
            this.condition = condition;
            messageAction = action;
        }

        public WhenDefinition(Predicate<TContext> condition, Func<IMessageSession, TContext, Task> actionWithContext)
        {
            Id = Guid.NewGuid();
            this.condition = condition;
            messageAndContextAction = actionWithContext;
        }

        public Guid Id { get; }

        public async Task<bool> ExecuteAction(ScenarioContext context, IMessageSession session)
        {
            var c = (TContext)context;

            if (!condition(c))
            {
                return false;
            }

            if (messageAction != null)
            {
                await messageAction(session).ConfigureAwait(false);
            }
            else
            {
                await messageAndContextAction(session, c).ConfigureAwait(false);
            }

            return true;
        }

        Predicate<TContext> condition;
        Func<IMessageSession, Task> messageAction;
        Func<IMessageSession, TContext, Task> messageAndContextAction;
    }
}