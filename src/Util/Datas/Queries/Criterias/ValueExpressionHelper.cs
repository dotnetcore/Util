using System;
using System.Linq.Expressions;

namespace Util.Datas.Queries.Criterias {
    /// <summary>
    /// 值表达式操作
    /// </summary>
    public static class ValueExpressionHelper {
        /// <summary>
        /// 获取日期常量表达式
        /// </summary>
        /// <param name="value">日期值</param>
        /// <param name="isNull">日期是否可空</param>
        public static Expression CreateDateTimeExpression( object value,bool isNull = true ) {
            Type type = isNull ? typeof( DateTime? ) : typeof( DateTime );
            return CreateDateTimeExpression( value, type );
        }

        /// <summary>
        /// 获取日期常量表达式
        /// </summary>
        /// <param name="value">日期值</param>
        /// <param name="targetType">目标类型</param>
        public static Expression CreateDateTimeExpression( object value, Type targetType ) {
            var parse = typeof( DateTime ).GetMethod( "Parse", new[] { typeof( string ) } );
            if( parse == null )
                return null;
            var parseExpression = Expression.Call( parse, Expression.Constant( value.SafeString() ) );
            return Expression.Convert( parseExpression, targetType );
        }
    }
}
