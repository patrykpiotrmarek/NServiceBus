namespace NServiceBus_6.AcceptanceTesting.Customization
{
    using System;

    public class Conventions
    {
        static Conventions()
        {
            EndpointNamingConvention = t => t.Name;
        }

        public static Func<Type, string> EndpointNamingConvention { get; set; }
    }
}