using Microsoft.Extensions.Hosting;
using Util;
using Util.Logging.Serilog;
using Util.Scheduling;

//启动应用
Host.CreateDefaultBuilder( args )
    .AddUtil( options => options
        .UseSerilog()
        .UseQuartz()
    )
    .Build()
    .Run();