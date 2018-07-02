using System;
using System.IO;
using System.Threading.Tasks;
using NServiceBus_6;
using NServiceBus_6.AcceptanceTesting.Support;
using NServiceBus_6.Persistence;

public class ConfigureEndpointLearningPersistence : IConfigureEndpointTestExecution
{
    public Task Configure(string endpointName, EndpointConfiguration configuration, RunSettings settings, PublisherMetadata publisherMetadata)
    {
        //can't use bindir since that will be to long on the build agents
        storageDir = Path.Combine(@"c:\temp", Guid.NewGuid().ToString("N"));

        configuration.UsePersistence<InMemoryPersistence, StorageType.Subscriptions>();
        configuration.UsePersistence<InMemoryPersistence, StorageType.Timeouts>();

        configuration.UsePersistence<LearningPersistence, StorageType.Sagas>()
            .SagaStorageDirectory(storageDir);

        return Task.FromResult(0);
    }

    public Task Cleanup()
    {
        if (Directory.Exists(storageDir))
        {
            Directory.Delete(storageDir, true);
        }
        return Task.FromResult(0);
    }

    string storageDir;
}