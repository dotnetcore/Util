using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Util.Data.Queries.Conditions {
    /// <summary>
    /// OrIfNotEmpty条件
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public class OrIfNotEmptyCondition<TEntity> : ICondition<TEntity> {
        /// <summary>
        /// 查询条件列表
        /// </summary>
        private readonly List<Expression<Func<TEntity, bool>>> _conditions;

        /// <summary>
        /// WhereIfNotEmpty条件
        /// </summary>
        /// <param name="condition1">查询条件1</param>
        /// <param name="condition2">查询条件2</param>
        /// <param name="conditions">查询条件列表</param>
        public OrIfNotEmptyCondition( Expression<Func<TEntity, bool>> condition1, Expression<Func<TEntity, bool>> condition2, params Expression<Func<TEntity, bool>>[] conditions ) {
            _conditions = new List<Expression<Func<TEntity, bool>>> { condition1, condition2 };
            _conditions.AddRange( conditions );
        }

        /// <summary>
        /// 获取查询条件
        /// </summary>
        public Expression<Func<TEntity, bool>> GetCondition() {
            Expression<Func<TEntity, bool>> result = null;
            foreach( var condition in _conditions ) {
                var predicate = new WhereIfNotEmptyCondition<TEntity>( condition ).GetCondition();
                if( predicate == null )
                    continue;
                result = result.Or( predicate );
            }
            return result;
        }
    }
}
