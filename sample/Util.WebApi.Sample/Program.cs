using Util;
using Util.Aop;
using Util.Logging.Serilog;

//创建Web应用程序生成器
var builder = WebApplication.CreateBuilder( args );

//配置服务
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//配置Util
builder.Host.AddUtil( options => options.UseAop()
    .UseSerilog( t => t.AddExceptionless() )
);

//构建Web应用程序
var app = builder.Build();

//配置请求管道
if ( app.Environment.IsDevelopment() ) {
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpLogging();
app.UseAuthorization();
app.MapControllers();

//运行应用
app.Run();
