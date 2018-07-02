namespace NServiceBus_6.AcceptanceTesting.Support
{
    public interface IEndpointConfigurationFactory
    {
        EndpointCustomizationConfiguration Get();
        ScenarioContext ScenarioContext { get; set; }
    }
}