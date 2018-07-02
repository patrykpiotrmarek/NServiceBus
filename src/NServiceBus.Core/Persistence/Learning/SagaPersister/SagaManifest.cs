namespace NServiceBus_6
{
    using System;
    using System.IO;

    class SagaManifest
    {
        public string StorageDirectory { get; set; }
        public Type SagaEntityType { get; set; }

        public string GetFilePath(Guid sagaId)
        {
            return Path.Combine(StorageDirectory, sagaId + ".json");
        }
    }
}