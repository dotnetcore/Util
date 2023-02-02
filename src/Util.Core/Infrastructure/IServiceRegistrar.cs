using System;

namespace Util.Infrastructure {
    /// <summary>
    /// 服务注册器
    /// </summary>
    public interface IServiceRegistrar {
        /// <summary>
        /// 排序号
        /// </summary>
        int OrderId { get; }

        /// <summary>
        /// 是否启用
        /// </summary>
        bool Enabled {
            get;
        }

        /// <summary>
        /// 注册服务,该操作在启动开始时执行,如果需要延迟执行某些操作,可在返回的Action中执行,它将在启动最后执行
        /// </summary>
        /// <param name="context">服务上下文</param>
        Action Register( ServiceContext context );
    }
}
