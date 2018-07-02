﻿namespace NServiceBus_6.Core.Tests.Routing
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using NServiceBus_6.Pipeline;
    using NServiceBus_6.Routing;
    using NUnit.Framework;
    using Testing;

    public class DetermineRouteForPublishBehaviorTests
    {
        [Test]
        public async Task Should_use_to_all_subscribers_strategy()
        {
            var behavior = new MulticastPublishRouterBehavior();

            var context = new TestableOutgoingPublishContext
            {
                Message = new OutgoingLogicalMessage(typeof(MyEvent), new MyEvent())
            };

            MulticastAddressTag addressTag = null;
            await behavior.Invoke(context, _ =>
            {
                addressTag = (MulticastAddressTag)_.RoutingStrategies.Single().Apply(new Dictionary<string, string>());
                return TaskEx.CompletedTask;
            });

            Assert.AreEqual(typeof(MyEvent), addressTag.MessageType);
        }

        class MyEvent
        { }
    }
}