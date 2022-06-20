using Util;
using Util.Aop;
using Util.Logging.Serilog;

//����WebӦ�ó���������
var builder = WebApplication.CreateBuilder( args );

//���÷���
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//����Util
builder.Host.AddUtil( options => options.UseAop()
    .UseSerilog( t => t.AddExceptionless() )
);

//����WebӦ�ó���
var app = builder.Build();

//��������ܵ�
if ( app.Environment.IsDevelopment() ) {
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpLogging();
app.UseAuthorization();
app.MapControllers();

//����Ӧ��
app.Run();
