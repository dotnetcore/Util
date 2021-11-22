using System;
using System.Linq.Expressions;
using Util.Dependency;

namespace Util.Data.Filters {
    /// <summary>
    /// 数据过滤器
    /// </summary>
    public interface IFilter : ITransientDependency {
        /// <summary>
        /// 过滤器是否启用
        /// </summary>
        bool IsEnabled { get; }
        /// <summary>
        /// 实体是否启用过滤器
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        bool IsEntityEnabled<TEntity>();
        /// <summary>
        /// 启用
        /// </summary>
        void Enable();
        /// <summary>
        /// 禁用
        /// </summary>
        IDisposable Disable();
        /// <summary>
        /// 获取过滤表达式
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        Expression<Func<TEntity, bool>> GetExpression<TEntity>() where TEntity : class;
    }

    /// <summary>
    /// 数据过滤器
    /// </summary>
    /// <typeparam name="TFilterType">过滤器类型</typeparam>
    public interface IFilter<TFilterType> : IFilter where TFilterType : class {
    }
}
