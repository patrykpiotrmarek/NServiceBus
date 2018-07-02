namespace NServiceBus_6
{
    using System.Collections.Generic;
    using Routing;

    interface IRouteSource
    {
        IEnumerable<RouteTableEntry> GenerateRoutes(Conventions conventions);
        RouteSourcePriority Priority { get; }
    }
}