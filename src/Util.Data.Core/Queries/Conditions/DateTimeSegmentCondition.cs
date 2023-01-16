using System;
using System.Linq.Expressions;
using Util.Helpers;

namespace Util.Data.Queries.Conditions {
    /// <summary>
    /// 日期范围过滤条件 - 包含时间
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TProperty">属性类型</typeparam>
    public class DateTimeSegmentCondition<TEntity, TProperty> : SegmentConditionBase<TEntity, TProperty, DateTime> where TEntity : class {
        /// <summary>
        /// 初始化日期范围过滤条件 - 包含时间
        /// </summary>
        /// <param name="propertyExpression">属性表达式</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public DateTimeSegmentCondition( Expression<Func<TEntity, TProperty>> propertyExpression, DateTime? min, DateTime? max, Boundary boundary = Boundary.Both )
            : base( propertyExpression, min, max, boundary ) {
        }

        /// <summary>
        /// 最小值是否大于最大值
        /// </summary>
        protected override bool IsMinGreaterMax( DateTime? min, DateTime? max ) {
            return min > max;
        }

        /// <summary>
        /// 获取日期常量表达式
        /// </summary>
        /// <param name="value">日期值</param>
        protected Expression CreateDateTimeExpression( object value ) {
            var parse = typeof( DateTime ).GetMethod( "Parse", new[] { typeof( string ) } );
            if( parse == null )
                return null;
            var parseExpression = Expression.Call( parse, Expression.Constant( value.SafeString() ) );
            return Expression.Convert( parseExpression, GetPropertyType() );
        }

        /// <summary>
        /// 获取最小值
        /// </summary>
        protected override Expression GetMinValueExpression() {
            var value = Time.Normalize( GetMinValue() );
            return CreateDateTimeExpression( value );
        }

        /// <summary>
        /// 获取最大值
        /// </summary>
        protected override Expression GetMaxValueExpression() {
            var value = Time.Normalize( GetMaxValue() );
            return CreateDateTimeExpression( value );
        }
    }
}
