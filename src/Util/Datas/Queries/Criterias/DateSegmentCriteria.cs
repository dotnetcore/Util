using System;
using System.Linq.Expressions;

namespace Util.Datas.Queries.Criterias {
    /// <summary>
    /// 日期范围过滤条件 - 不包含时间
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TProperty">属性类型</typeparam>
    public class DateSegmentCriteria<TEntity, TProperty> : SegmentCriteriaBase<TEntity, TProperty, DateTime> where TEntity : class {
        /// <summary>
        /// 初始化日期范围过滤条件 - 不包含时间
        /// </summary>
        /// <param name="propertyExpression">属性表达式</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public DateSegmentCriteria( Expression<Func<TEntity, TProperty>> propertyExpression, DateTime? min, DateTime? max, Boundary boundary = Boundary.Left )
            : base( propertyExpression, min, max, boundary ) {
        }

        /// <summary>
        /// 最小值是否大于最大值
        /// </summary>
        protected override bool IsMinGreaterMax( DateTime? min, DateTime? max ) {
            return min > max;
        }

        /// <summary>
        /// 获取最小值
        /// </summary>
        protected override Expression GetMinValueExpression() {
            return ValueExpressionHelper.CreateDateTimeExpression( GetMinValue().SafeValue().Date, GetPropertyType() );
        }

        /// <summary>
        /// 获取最大值
        /// </summary>
        protected override Expression GetMaxValueExpression() {
            return ValueExpressionHelper.CreateDateTimeExpression( GetMaxValue().SafeValue().Date.AddDays( 1 ), GetPropertyType() );
        }
    }
}
