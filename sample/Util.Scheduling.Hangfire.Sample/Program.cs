using Hangfire;
using Util;
using Util.Logging.Serilog;
using Util.Scheduling;

//����WebӦ�ó���������
var builder = WebApplication.CreateBuilder( args );

//���Util����
builder.Host.AddUtil( options => {
    options.UseSerilog()
    .UseHangfire( configuration => configuration
        .UseSqlServerStorage( builder.Configuration.GetConnectionString( "HangfireConnection" ) )
    );
} );

//���Mvc����
builder.Services.AddMvc();

//����WebӦ�ó���
var app = builder.Build();

//��������ܵ�
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

//����Ӧ��
app.Run();
