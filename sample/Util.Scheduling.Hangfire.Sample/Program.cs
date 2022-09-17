using Hangfire;
using Util;
using Util.Logging.Serilog;
using Util.Scheduling;

//创建Web应用程序生成器
var builder = WebApplication.CreateBuilder( args );

//添加Util服务
builder.Host.AddUtil( options => {
    options.UseSerilog()
    .UseHangfire( configuration => configuration
        .UseSqlServerStorage( builder.Configuration.GetConnectionString( "HangfireConnection" ) )
    );
} );

//添加Mvc服务
builder.Services.AddMvc();

//构建Web应用程序
var app = builder.Build();

//配置请求管道
if ( !app.Environment.IsDevelopment() ) {
    app.UseExceptionHandler( "/Error" );
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints( endpoints => {
    endpoints.MapControllers();
    endpoints.MapHangfireDashboard();
} );

//运行应用
app.Run();
