using System;
using System.Linq.Expressions;
using Nest;
using Util.Datas.Queries;

namespace Util.Search.ElasticSearch.Services.Conditions {
    /// <summary>
    /// 日期范围过滤条件 - 包含时间
    /// </summary>
    public class DateTimeRangeCondition<TEntity, TProperty> : RangeConditionBase<TEntity, TProperty, DateTime, DateRangeQuery> where TEntity : class {
        /// <summary>
        /// 初始化日期范围过滤条件
        /// </summary>
        /// <param name="propertyExpression">属性表达式</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public DateTimeRangeCondition( Expression<Func<TEntity, TProperty>> propertyExpression, DateTime? min, DateTime? max, Boundary boundary = Boundary.Both )
            : base( propertyExpression, min, max, boundary ) {
        }

        /// <summary>
        /// 最小值是否大于最大值
        /// </summary>
        protected override bool IsMinGreaterMax( DateTime? min, DateTime? max ) {
            return min > max;
        }

        /// <summary>
        /// 创建查询条件
        /// </summary>
        protected override DateRangeQuery CreateCondition() {
            return new DateRangeQuery();
        }

        /// <summary>
        /// 设置字段
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="field">字段</param>
        protected override void SetField( DateRangeQuery condition, Field field ) {
            condition.Field = field;
        }

        /// <summary>
        /// 设置大于等于操作
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="min">最小值</param>
        protected override void SetGreaterEqual( DateRangeQuery condition, DateTime? min ) {
            condition.GreaterThanOrEqualTo = min;
        }

        /// <summary>
        /// 设置大于操作
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="min">最小值</param>
        protected override void SetGreater( DateRangeQuery condition, DateTime? min ) {
            condition.GreaterThan = min;
        }

        /// <summary>
        /// 设置小于等于操作
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="max">最大值</param>
        protected override void SetLessEqual( DateRangeQuery condition, DateTime? max ) {
            condition.LessThanOrEqualTo = max;
        }

        /// <summary>
        /// 设置小于操作
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="max">最大值</param>
        protected override void SetLess( DateRangeQuery condition, DateTime? max ) {
            condition.LessThan = max;
        }
    }
}
