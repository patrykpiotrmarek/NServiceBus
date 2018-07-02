namespace NServiceBus_6
{
    using System.Xml.Linq;

    interface IInstanceMappingFileAccess
    {
        XDocument Load(string path);
    }
}