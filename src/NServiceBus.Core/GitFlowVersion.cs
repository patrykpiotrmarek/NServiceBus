namespace NServiceBus_6
{
    using System;

    static class GitFlowVersion
    {
        static GitFlowVersion()
        {
            var assembly = typeof(GitFlowVersion).Assembly;
            var gitFlowVersionInformationType = assembly.GetType("NServiceBus_6.GitVersionInformation", true);
            var fieldInfo = gitFlowVersionInformationType.GetField("MajorMinorPatch");
            var majorMinorPatchVersion = Version.Parse((string) fieldInfo.GetValue(null));
            MajorMinor = majorMinorPatchVersion.ToString(2);
            MajorMinorPatch = majorMinorPatchVersion.ToString(3);
        }

        public static string MajorMinor;
        public static string MajorMinorPatch;
    }
}