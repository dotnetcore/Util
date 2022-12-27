using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Util;
using Util.Logging.Serilog;
using Util.Scheduling;
using Util.Scheduling.Quartz.Sample.Services;

//启动应用
Host.CreateDefaultBuilder( args )
    .ConfigureServices( services => services.AddHostedService<HostService2>() )
    .AddUtil( options => options
        .UseSerilog()
        .UseQuartz(false)
    )
    .Build()
    .Run();