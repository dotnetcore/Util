using System;
using System.Linq.Expressions;
using Util.Domains;

namespace Util.Datas.Queries.Criterias {
    /// <summary>
    /// 日期范围过滤条件 - 不包含时间
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TProperty">属性类型</typeparam>
    public class DateSegmentCriteria<TEntity, TProperty> : SegmentCriteriaBase<TEntity, TProperty, DateTime> where TEntity : class,IAggregateRoot {
        /// <summary>
        /// 初始化日期范围过滤条件 - 不包含时间
        /// </summary>
        /// <param name="propertyExpression">属性表达式</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        public DateSegmentCriteria( Expression<Func<TEntity, TProperty>> propertyExpression, DateTime? min, DateTime? max )
            : base( propertyExpression, min, max ) {
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
        protected override DateTime? GetMinValue() {
            return base.GetMinValue().SafeValue().Date;
        }

        /// <summary>
        /// 获取最大值
        /// </summary>
        protected override DateTime? GetMaxValue() {
            return base.GetMaxValue().SafeValue().Date.AddDays( 1 );
        }

        /// <summary>
        /// 获取最大值相关的运算符
        /// </summary>
        protected override Operator GetMaxOperator() {
            return Operator.Less;
        }
    }
}
