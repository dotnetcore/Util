using System;
using System.Linq.Expressions;

namespace Util.Data.Queries.Conditions {
    /// <summary>
    /// 默认查询条件
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public class DefaultCondition<TEntity> : ICondition<TEntity> where TEntity : class {
        /// <summary>
        /// 查询条件
        /// </summary>
        private readonly Expression<Func<TEntity, bool>> _condition;

        /// <summary>
        /// 初始化查询条件
        /// </summary>
        /// <param name="condition">查询条件</param>
        public DefaultCondition( Expression<Func<TEntity, bool>> condition ) {
            _condition = condition;
        }

        /// <summary>
        /// 获取查询条件
        /// </summary>
        public Expression<Func<TEntity, bool>> GetCondition() {
            return _condition;
        }
    }
}
