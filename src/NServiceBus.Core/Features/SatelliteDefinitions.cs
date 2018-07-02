namespace NServiceBus_6
{
    using System.Collections.Generic;

    class SatelliteDefinitions
    {
        public List<SatelliteDefinition> Definitions { get; } = new List<SatelliteDefinition>();

        public void Add(SatelliteDefinition satelliteDefinition)
        {
            Definitions.Add(satelliteDefinition);
        }
    }
}