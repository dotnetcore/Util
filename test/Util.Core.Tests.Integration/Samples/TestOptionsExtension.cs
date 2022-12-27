using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Util.Configs;

namespace Util.Tests.Samples {
    /// <summary>
    /// 测试配置扩展
    /// </summary>
    public static class TestOptionsExtensions {
        /// <summary>
        /// 配置
        /// </summary>
        public static Options UseTest( this Options options ) {
            options.AddExtension( new TestOptionsExtension() );
            return options;
        }
    }

    /// <summary>
    /// 测试配置项扩展
    /// </summary>
    public class TestOptionsExtension : OptionsExtensionBase {
        /// <inheritdoc />
        public override void ConfigureServices( HostBuilderContext context, IServiceCollection services ) {
            var service = new TestService { Value = "Options" };
            services.TryAddSingleton<ITestService>( service );

            var service2 = new TestService2 { Value = "Options" };
            services.TryAddSingleton<ITestService2>( service2 );

            var service3 = new TestService3 { Value = "Options" };
            services.TryAddSingleton<ITestService3>( service3 );
        }
    }
}
