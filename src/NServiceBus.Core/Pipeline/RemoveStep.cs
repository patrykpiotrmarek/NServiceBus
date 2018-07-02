namespace NServiceBus_6
{
    class RemoveStep
    {
        public RemoveStep(string removeId)
        {
            RemoveId = removeId;
        }

        public string RemoveId { get; private set; }
    }
}