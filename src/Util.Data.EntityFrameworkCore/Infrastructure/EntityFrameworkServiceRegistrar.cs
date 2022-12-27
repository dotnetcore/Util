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
        /// 获取标识
        /// </summary>
        public static int GetId() => 710;

        /// <summary>
        /// 标识
        /// </summary>
        public int Id => GetId();

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled => ServiceRegistrarConfig.Instance.IsEnabled( GetId() );

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
