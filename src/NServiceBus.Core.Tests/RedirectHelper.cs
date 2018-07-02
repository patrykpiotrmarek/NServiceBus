using System;
using System.Reflection;
using NServiceBus_6;
using NUnit.Framework;

//binding redirect in code to avoid need to update the bindingredirect in app.config for TestAssembly.dll
[SetUpFixture]
public class RedirectHelper
{
    [OneTimeSetUp]
    public void Initialize()
    {
        AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
    }

    static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
        if (args.Name.StartsWith("NServiceBus_6.Core,"))
        {
            return typeof(IMessage).Assembly;
        }
        return null;
    }
}