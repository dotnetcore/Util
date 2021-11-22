using System;
using System.Linq.Expressions;

namespace Util.Data.Queries.Conditions {
    /// <summary>
    /// decimal范围过滤条件
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TProperty">属性类型</typeparam>
    public class DecimalSegmentCondition<TEntity, TProperty> : SegmentConditionBase<TEntity, TProperty, decimal> where TEntity : class {
        /// <summary>
        /// 初始化decimal范围过滤条件
        /// </summary>
        /// <param name="propertyExpression">属性表达式</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public DecimalSegmentCondition( Expression<Func<TEntity, TProperty>> propertyExpression, decimal? min, decimal? max, Boundary boundary = Boundary.Both )
            : base( propertyExpression, min, max, boundary ) {
        }

        /// <summary>
        /// 最小值是否大于最大值
        /// </summary>
        protected override bool IsMinGreaterMax( decimal? min, decimal? max ) {
            return min > max;
        }
    }
}
