namespace NServiceBus_6
{
    using System;
    using System.Collections.Generic;

    static class SagaStorageFileExtensions
    {
        public static void RegisterSagaFile(this Dictionary<string, SagaStorageFile> sagaFiles, SagaStorageFile sagaStorageFile, Guid sagaId, Type sagaDataType)
        {
            sagaFiles[$"{sagaDataType.FullName}{sagaId}"] = sagaStorageFile;
        }
    }
}