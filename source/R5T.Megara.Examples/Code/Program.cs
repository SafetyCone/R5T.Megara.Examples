using System;
using System.Collections.Generic;

using Microsoft.Extensions.DependencyInjection;

using R5T.Chalandri;
using R5T.Evosmos;
using R5T.Ilioupoli.Default;
using R5T.Richmond;


namespace R5T.Megara.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = ServiceProviderBuilder.NewUseStartup<Startup>();

            var program = serviceProvider.GetRequiredService<Program>();

            program.Run();
        }


        private ITestingDataDirectoryContentPathsProvider TestingDataDirectoryContentPathsProvider { get; }
        private ITemporaryDirectoryFilePathProvider TemporaryDirectoryFilePathProvider { get; }
        private IFileSerializer<List<string>> LinesTextFileSerializer { get; }


        public Program(
            ITestingDataDirectoryContentPathsProvider testingDataDirectoryContentPathsProvider,
            ITemporaryDirectoryFilePathProvider temporaryDirectoryFilePathProvider,
            IFileSerializer<List<string>> linesTextFileSerializer)
        {
            this.TestingDataDirectoryContentPathsProvider = testingDataDirectoryContentPathsProvider;
            this.TemporaryDirectoryFilePathProvider = temporaryDirectoryFilePathProvider;
            this.LinesTextFileSerializer = linesTextFileSerializer;
        }

        public void Run()
        {
            var sourceBasicTextFilePath = this.TestingDataDirectoryContentPathsProvider.GetBasicTextFilePath();

            var fileName = TestingDataDirectoryContentConventions.BasicTextFileNameValue;
            var destinationFilePath = this.TemporaryDirectoryFilePathProvider.GetTemporaryDirectoryFilePath(fileName);

            var lines = this.LinesTextFileSerializer.Deserialize(sourceBasicTextFilePath);

            var writer = Console.Out;
            foreach (var line in lines)
            {
                writer.WriteLine(line);
            }

            this.LinesTextFileSerializer.Serialize(destinationFilePath, lines);
        }
    }
}
