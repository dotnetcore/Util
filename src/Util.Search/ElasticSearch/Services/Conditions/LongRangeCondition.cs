using System;
using System.Linq.Expressions;
using Nest;
using Util.Datas.Queries;

namespace Util.Search.ElasticSearch.Services.Conditions {
    /// <summary>
    /// long范围过滤条件
    /// </summary>
    public class LongRangeCondition<TEntity, TProperty> : RangeConditionBase<TEntity, TProperty, long, LongRangeQuery> where TEntity : class {
        /// <summary>
        /// 初始化long范围过滤条件
        /// </summary>
        /// <param name="propertyExpression">属性表达式</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public LongRangeCondition( Expression<Func<TEntity, TProperty>> propertyExpression, long? min, long? max, Boundary boundary = Boundary.Both )
            : base( propertyExpression, min, max, boundary ) {
        }

        /// <summary>
        /// 最小值是否大于最大值
        /// </summary>
        protected override bool IsMinGreaterMax( long? min, long? max ) {
            return min > max;
        }

        /// <summary>
        /// 创建查询条件
        /// </summary>
        protected override LongRangeQuery CreateCondition() {
            return new LongRangeQuery();
        }

        /// <summary>
        /// 设置字段
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="field">字段</param>
        protected override void SetField( LongRangeQuery condition, Field field ) {
            condition.Field = field;
        }

        /// <summary>
        /// 设置大于等于操作
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="min">最小值</param>
        protected override void SetGreaterEqual( LongRangeQuery condition, long? min ) {
            condition.GreaterThanOrEqualTo = min;
        }

        /// <summary>
        /// 设置大于操作
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="min">最小值</param>
        protected override void SetGreater( LongRangeQuery condition, long? min ) {
            condition.GreaterThan = min;
        }

        /// <summary>
        /// 设置小于等于操作
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="max">最大值</param>
        protected override void SetLessEqual( LongRangeQuery condition, long? max ) {
            condition.LessThanOrEqualTo = max;
        }

        /// <summary>
        /// 设置小于操作
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="max">最大值</param>
        protected override void SetLess( LongRangeQuery condition, long? max ) {
            condition.LessThan = max;
        }
    }
}
