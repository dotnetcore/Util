using Microsoft.AspNetCore.Authentication.JwtBearer;
using Util.Logging.Serilog;
using Util.Microservices.Dapr.WebApiSample.Authorization;

var builder = WebApplication.CreateBuilder( args );

builder.Services.AddControllers();
builder.Services.AddAuthentication( JwtBearerDefaults.AuthenticationScheme )
    .AddJwtBearer( options => {
        options.Authority = builder.Configuration.GetValue<string>( "IdentityUrl" );
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters.ValidateAudience = false;
        options.TokenValidationParameters.ValidateIssuer = false;
    } );
builder.AsBuild()
    .AddAcl<PermissionManager>()
    .AddSerilog( "Util.Microservices.Dapr.WebApiSample" )
    .AddUtil();

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
