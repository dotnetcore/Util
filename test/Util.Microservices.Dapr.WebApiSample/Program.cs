using Util.Helpers;
using Util.Logging.Serilog;
using Util.Microservices.Dapr;

var builder = WebApplication.CreateBuilder( args );

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.AsBuild()
    .AddSerilog( "Util.Microservices.Dapr.WebApiSample" )
    .AddDapr()
    .AddUtil();

var app = builder.Build();
app.UseCloudEventHeaders();
app.UseCloudEvents();
app.UseSwagger();
app.UseSwaggerUI( options => {
    options.DocumentTitle = "Util.Microservices.Dapr.WebApiSample";
} );
app.MapControllers();
app.Run();
