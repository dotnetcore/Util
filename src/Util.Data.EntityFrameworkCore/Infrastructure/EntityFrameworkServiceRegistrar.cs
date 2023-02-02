using System;
using Util.Data.EntityFrameworkCore.Filters;
using Util.Domain;
using Util.Infrastructure;

namespace Util.Data.EntityFrameworkCore.Infrastructure {
    /// <summary>
    /// EntityFrameworkCore服务注册器
    /// </summary>
    public class EntityFrameworkServiceRegistrar : IServiceRegistrar {
        /// <summary>
        /// 获取服务名
        /// </summary>
        public static string ServiceName => "Util.Data.EntityFrameworkCore.Infrastructure.EntityFrameworkServiceRegistrar";

        /// <summary>
        /// 排序号
        /// </summary>
        public int OrderId => 710;

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled => ServiceRegistrarConfig.IsEnabled( ServiceName );

        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="serviceContext">服务上下文</param>
        public Action Register( ServiceContext serviceContext ) {
            FilterManager.AddFilterType<IDelete>();
            return null;
        }
    }
}
