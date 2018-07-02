﻿namespace NServiceBus_6.AcceptanceTests.Core.Persistence
{
    using System.Threading.Tasks;
    using AcceptanceTesting;
    using EndpointTemplates;
    using Features;
    using NServiceBus_6.Persistence;
    using NUnit.Framework;

    public class When_a_persistence_does_not_support_timeouts : NServiceBusAcceptanceTest
    {
        [Test]
        public void should_throw_exception()
        {
            Requires.TimeoutStorage();

            Assert.That(async () =>
            {
                await Scenario.Define<Context>()
                    .WithEndpoint<Endpoint>(e => e.When(b => Task.FromResult(0)))
                    .Run();
            }, Throws.Exception.With.Message.Contains("DisableFeature<TimeoutManager>()"));
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
                    c.UsePersistence<InMemoryPersistence, StorageType.Subscriptions>();

                    c.EnableFeature<TimeoutManager>();
                });
            }
        }

        public class Context : ScenarioContext
        {
            public bool MessageReceived { get; set; }
        }
    }
}