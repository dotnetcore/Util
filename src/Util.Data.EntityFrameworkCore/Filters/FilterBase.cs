using System;
using System.Linq.Expressions;
using Util.Data.Filters;

namespace Util.Data.EntityFrameworkCore.Filters {
    /// <summary>
    /// 数据过滤器基类
    /// </summary>
    /// <typeparam name="TFilterType">过滤器类型</typeparam>
    public abstract class FilterBase<TFilterType> : IFilter<TFilterType> where TFilterType : class {
        /// <summary>
        /// 过滤器是否启用
        /// </summary>
        public bool IsEnabled { get; private set; } = true;

        /// <summary>
        /// 实体是否启用过滤器
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        public bool IsEntityEnabled<TEntity>() {
            return typeof(TFilterType).IsAssignableFrom( typeof(TEntity) );
        }

        /// <summary>
        /// 启用
        /// </summary>
        public void Enable() {
            IsEnabled = true;
        }

        /// <summary>
        /// 禁用
        /// </summary>
        public IDisposable Disable() {
            if ( IsEnabled == false )
                return DisposeAction.Null;
            IsEnabled = false;
            return new DisposeAction( Enable );
        }

        /// <summary>
        /// 获取过滤表达式
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        public abstract Expression<Func<TEntity, bool>> GetExpression<TEntity>() where TEntity : class;
    }
}
