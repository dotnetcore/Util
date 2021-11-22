using System;
using Util.Dependency;

namespace Util.Data.Filters {
    /// <summary>
    /// 数据过滤器管理器
    /// </summary>
    public interface IFilterManager : IFilterSwitch,IScopeDependency {
        /// <summary>
        /// 获取过滤器
        /// </summary>
        /// <typeparam name="TFilterType">过滤器类型</typeparam>
        IFilter GetFilter<TFilterType>() where TFilterType : class;
        /// <summary>
        /// 获取过滤器
        /// </summary>
        /// <param name="filterType">过滤器类型</param>
        IFilter GetFilter( Type filterType );
        /// <summary>
        /// 实体是否启用过滤器
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        bool IsEntityEnabled<TEntity>();
        /// <summary>
        /// 过滤器是否启用
        /// </summary>
        /// <typeparam name="TFilterType">过滤器类型</typeparam>
        bool IsEnabled<TFilterType>() where TFilterType : class;
    }
}
