﻿namespace NServiceBus_6.Core.Tests.AssemblyScanner
{
    using System.IO;
    using NUnit.Framework;

    [TestFixture]
    public class When_checking_image_type
    {
        [Test]
        public void roslyn_x86_image_type_correctly_detected()
        {
            var file = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestDlls", "RoslynX86.dll");

            var compilationMode = Image.GetCompilationMode(file);

            Assert.That(compilationMode, Is.EqualTo(Image.CompilationMode.CLRx86));
        }

        [Test]
        public void roslyn_x64_image_type_correctly_detected()
        {
            var file = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestDlls", "RoslynX64.dll");

            var compilationMode = Image.GetCompilationMode(file);

            Assert.That(compilationMode, Is.EqualTo(Image.CompilationMode.CLRx64));
        }
    }
}