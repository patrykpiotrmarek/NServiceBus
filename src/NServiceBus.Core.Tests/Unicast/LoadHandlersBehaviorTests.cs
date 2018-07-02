﻿namespace NServiceBus_6.Unicast.Tests
{
    using Outbox;
    using NServiceBus_6.Transport;
    using NUnit.Framework;
    using Testing;

    [TestFixture]
    public class LoadHandlersBehaviorTests
    {
        [Test]
        public void Should_throw_when_there_are_no_registered_message_handlers()
        {
            var behavior = new LoadHandlersConnector(new MessageHandlerRegistry(new Conventions()), new InMemorySynchronizedStorage(), new InMemoryTransactionalSynchronizedStorageAdapter());

            var context = new TestableIncomingLogicalMessageContext();

            context.Extensions.Set<OutboxTransaction>(new InMemoryOutboxTransaction());
            context.Extensions.Set(new TransportTransaction());

            Assert.That(async () => await behavior.Invoke(context, c => TaskEx.CompletedTask), Throws.InvalidOperationException);
        }
    }
}