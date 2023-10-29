using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Util.Infrastructure;
using Util.Tests.Samples;
using Xunit;

namespace Util.Tests.Infrastructure; 

/// <summary>
/// 启动器测试
/// </summary>
public class BootstrapperTest {
    /// <summary>
    /// 测试启动时解析服务注册器
    /// 说明:
    /// 1. 有两个测试服务注册器TestServiceRegistrar和TestServiceRegistrar2
    /// 2. TestServiceRegistrar的Id更小,所以先执行
    /// 3. TestServiceRegistrar2使用services.TryAddSingleton进行依赖注册,由于之前已经添加过依赖,所以不会再次添加,TestServiceRegistrar的依赖配置生效
    /// </summary>
    [Fact]
    public void TestStart_1() {
        var builder = new HostBuilder();
        var bootstrapper = new Bootstrapper( builder );
        bootstrapper.Start();
        var host = builder.Build();
        Assert.Equal( "a", host.Services.GetService<IA>()?.Value );
    }
}