using System;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Util.Infrastructure;

namespace Util.Tests.Samples {
    /// <summary>
    /// 测试服务注册器
    /// </summary>
    public class TestServiceRegistrar : IServiceRegistrar {
        /// <summary>
        /// 获取服务名
        /// </summary>
        public static string ServiceName => "TestServiceRegistrar";

        /// <summary>
        /// 排序号
        /// </summary>
        public int OrderId => 100;

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled => ServiceRegistrarConfig.IsEnabled( ServiceName );

        /// <summary>
        /// 注册服务
        /// </summary>
        public Action Register( ServiceContext serviceContext ) {
            A a = new A { Value = "a" };
            serviceContext.HostBuilder.ConfigureServices( ( context, services ) => {
                services.TryAddSingleton<IA>( a );
            } );
            return null;
        }
    }

    /// <summary>
    /// 测试服务注册器2
    /// </summary>
    public class TestServiceRegistrar2 : IServiceRegistrar {
        /// <summary>
        /// 获取服务名
        /// </summary>
        public static string ServiceName => "TestServiceRegistrar2";

        /// <summary>
        /// 排序号
        /// </summary>
        public int OrderId => 200;

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled => ServiceRegistrarConfig.IsEnabled( ServiceName );

        /// <summary>
        /// 注册服务
        /// </summary>
        public Action Register( ServiceContext serviceContext ) {
            A a = new A { Value = "b" };
            serviceContext.HostBuilder.ConfigureServices( ( context, services ) => {
                services.TryAddSingleton<IA>( a );
            } );
            return null;
        }
    }

    /// <summary>
    /// 测试服务注册器
    /// </summary>
    public class TestServiceRegistrar3 : IServiceRegistrar {
        /// <summary>
        /// 获取服务名
        /// </summary>
        public static string ServiceName => "TestServiceRegistrar3";

        /// <summary>
        /// 排序号
        /// </summary>
        public int OrderId => 300;

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled => ServiceRegistrarConfig.IsEnabled( ServiceName );

        /// <summary>
        /// 注册服务
        /// </summary>
        public Action Register( ServiceContext serviceContext ) {
            var service = new TestService2 { Value = "a" };
            serviceContext.HostBuilder.ConfigureServices( ( context, services ) => {
                services.TryAddSingleton<ITestService2>( service );
            } );
            return null;
        }
    }

    /// <summary>
    /// 测试服务注册器
    /// </summary>
    public class TestServiceRegistrar4 : IServiceRegistrar {
        /// <summary>
        /// 获取服务名
        /// </summary>
        public static string ServiceName => "TestServiceRegistrar3";

        /// <summary>
        /// 排序号
        /// </summary>
        public int OrderId => 400;

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled => ServiceRegistrarConfig.IsEnabled( ServiceName );

        /// <summary>
        /// 注册服务
        /// </summary>
        public Action Register( ServiceContext serviceContext ) {
            return () => {
                var service = new TestService3 { Value = "a" };
                serviceContext.HostBuilder.ConfigureServices( ( context, services ) => {
                    services.TryAddSingleton<ITestService3>( service );
                } );
            };
        }
    }
}
