using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Util.Configs;
using Util.Dependency;
using Util.Helpers;
using Util.Reflections;

namespace Util.Infrastructure {
    /// <summary>
    /// 启动器
    /// </summary>
    public class Bootstrapper {
        /// <summary>
        /// 服务集合
        /// </summary>
        private readonly IServiceCollection _services;
        /// <summary>
        /// 服务配置
        /// </summary>
        private readonly Action<Options> _setupAction;
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfiguration _configuration;
        /// <summary>
        /// 类型查找器
        /// </summary>
        private readonly ITypeFinder _finder;
        /// <summary>
        /// 服务配置操作列表
        /// </summary>
        private readonly List<Action> _serviceActions;

        /// <summary>
        /// 初始化启动器
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="setupAction">服务配置操作</param>
        /// <param name="configuration">配置</param>
        public Bootstrapper( IServiceCollection services, Action<Options> setupAction = null, IConfiguration configuration = null ) {
            _services = services ?? throw new ArgumentNullException( nameof( services ) );
            _setupAction = setupAction;
            _configuration = configuration;
            var assemblyFinder = new AppDomainAssemblyFinder { AssemblySkipPattern = BootstrapperConfig.AssemblySkipPattern };
            _finder = new AppDomainTypeFinder( assemblyFinder );
            _serviceActions = new List<Action>();
        }

        /// <summary>
        /// 启动
        /// </summary>
        public void Start() {
            ResolveServiceRegistrar();
            ConfigOptions();
            ResolveDependencyRegistrar();
            ExecuteServiceActions();
        }

        /// <summary>
        /// 解析服务注册器
        /// </summary>
        private void ResolveServiceRegistrar() {
            var types = _finder.Find<IServiceRegistrar>();
            var instances = types.Select( type => Reflection.CreateInstance<IServiceRegistrar>( type ) ).Where( t => t.Enabled ).OrderBy( t => t.Id ).ToList();
            instances.ForEach( t => _serviceActions.Add( t.Register( _services, _configuration, _finder ) ) );
        }

        /// <summary>
        /// 注册配置项
        /// </summary>
        private void ConfigOptions() {
            _services.AddOptions( _setupAction );
        }

        /// <summary>
        /// 解析依赖注册器
        /// </summary>
        private void ResolveDependencyRegistrar() {
            var types = _finder.Find<IDependencyRegistrar>();
            var instances = types.Select( type => Reflection.CreateInstance<IDependencyRegistrar>( type ) ).OrderBy( t => t.Order ).ToList();
            instances.ForEach( t => t.Register( _services ) );
        }

        /// <summary>
        /// 执行延迟服务注册操作
        /// </summary>
        private void ExecuteServiceActions() {
            _serviceActions.ForEach( action => action?.Invoke() );
        }
    }
}
