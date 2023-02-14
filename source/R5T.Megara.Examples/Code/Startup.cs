using System;
using System.Collections.Generic;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using R5T.Chalandri.DropboxRivetTestingData;
using R5T.Evosmos.CDriveTemp;
using R5T.Megara.TextSerializer;
using R5T.Richmond;

using R5T.Megara.Examples.Lib;


namespace R5T.Megara.Examples
{
    public class Startup : StartupBase
    {
        public Startup(ILogger<Startup> logger)
            : base(logger)
        {
        }

        protected override void ConfigureServicesBody(IServiceCollection services)
        {
            services
                .AddSingleton<Program>()
                //.AddTextFileSerializer<List<string>, LinesTextSerializer>()
                .AddTestingDataDirectoryContentPathsProvider()
                .AddTemporaryDirectoryFilePathProvider()
                ;
        }
    }
}
