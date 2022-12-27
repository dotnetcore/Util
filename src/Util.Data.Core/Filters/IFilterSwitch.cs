using System;

namespace Util.Data.Filters {
    /// <summary>
    /// 数据过滤器开关
    /// </summary>
    public interface IFilterSwitch {
        /// <summary>
        /// 启用过滤器
        /// </summary>
        /// <typeparam name="TFilterType">过滤器类型</typeparam>
        void EnableFilter<TFilterType>() where TFilterType : class;
        /// <summary>
        /// 禁用过滤器
        /// </summary>
        /// <typeparam name="TFilterType">过滤器类型</typeparam>
        IDisposable DisableFilter<TFilterType>() where TFilterType : class;
    }
}
