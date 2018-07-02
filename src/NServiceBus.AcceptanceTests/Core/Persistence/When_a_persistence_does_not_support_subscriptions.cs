namespace NServiceBus_6.AcceptanceTests.Core.Persistence
{
    using AcceptanceTesting;
    using EndpointTemplates;
    using NServiceBus_6.Persistence;
    using NUnit.Framework;

    public class When_a_persistence_does_not_support_subscriptions : NServiceBusAcceptanceTest
    {
        [Test]
        public void should_throw_exception()
        {
            Requires.MessageDrivenPubSub();

            Assert.That(async () =>
            {
                await Scenario.Define<Context>()
                    .WithEndpoint<Endpoint>(e => e.When(b => b.Subscribe<object>()))
                    .Run();
            }, Throws.Exception.With.Message.Contains("DisableFeature<MessageDrivenSubscriptions>()"));
        }

        class Endpoint : EndpointConfigurationBuilder
        {
            public Endpoint()
            {
                EndpointSetup<ServerWithNoDefaultPersistenceDefinitions>(c =>
                {
                    c.UsePersistence<InMemoryPersistence, StorageType.Sagas>();
                    c.UsePersistence<InMemoryPersistence, StorageType.GatewayDeduplication>();
                    c.UsePersistence<InMemoryPersistence, StorageType.Outbox>();
                    c.UsePersistence<InMemoryPersistence, StorageType.Timeouts>();
                });
            }
        }

        public class Context : ScenarioContext
        {
            public bool MessageReceived { get; set; }
        }
    }
}