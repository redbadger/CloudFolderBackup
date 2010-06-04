// <auto-generated />
// ReSharper disable InconsistentNaming
#pragma warning disable 169

namespace RedBadger.CloudFolderBackup.Specs
{
    using System;
    using System.IO;

    using com.mosso.cloudfiles;

    using Machine.Specifications;

    using Rhino.Mocks;

    public abstract class a_Runner
    {
        protected static IFolderConnection sourceFolder;

        protected static IConnection cloudConnection;

        protected static IRunner runner;

        private Establish context = () =>
            {
                sourceFolder = MockRepository.GenerateStub<IFolderConnection>();
                cloudConnection = MockRepository.GenerateStub<IConnection>();
                runner = new Runner(sourceFolder, cloudConnection);
            };
    }

    [Subject(typeof(Runner))]
    public class when_started_with_a_nonexistant_folder : a_Runner
    {
        private const string containerName = "Container";

        static Exception Exception;

        private Establish context = () => sourceFolder.Expect(c => c.IsValid()).Return(false);

        private Because of = () => Exception = Catch.Exception(() => runner.Run(containerName));

        private It should_fail = () => Exception.ShouldBeOfType<DirectoryNotFoundException>();
    }

    [Subject(typeof(Runner))]
    public class when_started_with_a_nonexistant_cloud_container : a_Runner
    {
        static Exception Exception;

        Establish context = () => sourceFolder.Expect(c => c.IsValid()).Return(true);

        private Because of = () => Exception = Catch.Exception(() => runner.Run("Container"));

        private It should_fail = () => Exception.ShouldBeOfType<IndexOutOfRangeException>();
    }
}