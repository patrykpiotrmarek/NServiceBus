namespace NServiceBus_6.Features
{
    using System;
    using NServiceBus_6.DataBus;

    class DataBusFileBased : Feature
    {
        public DataBusFileBased()
        {
            DependsOn<DataBus>();
        }

        /// <summary>
        /// See <see cref="Feature.Setup" />
        /// </summary>
        protected internal override void Setup(FeatureConfigurationContext context)
        {
            string basePath;
            if (!context.Settings.TryGet("FileShareDataBusPath", out basePath))
            {
                throw new InvalidOperationException("Specify the basepath for FileShareDataBus, eg endpointConfiguration.UseDataBus<FileShareDataBus>().BasePath(\"c:\\databus\")");
            }
            var dataBus = new FileShareDataBusImplementation(basePath);

            context.Container.RegisterSingleton<IDataBus>(dataBus);
        }
    }
}