using Util.Helpers;
using Util.Logging.Serilog;
using Util.Microservices.Dapr;

var builder = WebApplication.CreateBuilder( args );
builder.Services.AddControllers();
builder.AsBuild()
    .AddSerilog( "Util.Microservices.Dapr.PubsubSample" )
    .AddDapr( t => t.AppId = "app_pubsub", daprBuilder => {
        daprBuilder.UseHttpEndpoint( $"http://127.0.0.1:{Config.GetValue( "DaprPorts:HttpPort" )}" )
            .UseGrpcEndpoint( $"http://127.0.0.1:{Config.GetValue( "DaprPorts:GrpcPort" )}" );
    } )
    .AddUtil();

var app = builder.Build();
app.UseCloudEventHeaders();
app.UseCloudEvents();
app.MapSubscribeHandler();
app.MapControllers();
app.Run();