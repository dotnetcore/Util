using System;
using System.Linq.Expressions;
using Util.Datas.Queries;

namespace Util.Search.ElasticSearch.Services.Conditions {
    /// <summary>
    /// 日期范围过滤条件 - 不包含时间
    /// </summary>
    public class DateRangeCondition<TEntity, TProperty> : DateTimeRangeCondition<TEntity, TProperty> where TEntity : class {
        /// <summary>
        /// 初始化日期范围过滤条件
        /// </summary>
        /// <param name="propertyExpression">属性表达式</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public DateRangeCondition( Expression<Func<TEntity, TProperty>> propertyExpression, DateTime? min, DateTime? max, Boundary boundary = Boundary.Both )
            : base( propertyExpression, min, max, boundary ) {
        }

        /// <summary>
        /// 获取最小值
        /// </summary>
        protected override DateTime? GetMinValue() {
            return base.GetMinValue().SafeValue().Date;
        }

        /// <summary>
        /// 获取最大值
        /// </summary>
        protected override DateTime? GetMaxValue() {
            return base.GetMaxValue().SafeValue().Date.AddDays( 1 );
        }
    }
}
