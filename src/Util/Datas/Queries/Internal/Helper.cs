using System;
using System.Linq.Expressions;
using Util.Helpers;
using Util.Properties;

namespace Util.Datas.Queries.Internal {
    /// <summary>
    /// 查询工具类
    /// </summary>
    internal static class Helper {
        /// <summary>
        /// 获取查询条件表达式
        /// </summary>
        /// <param name="predicate">查询条件,如果参数值为空，则忽略该查询条件，范例：t => t.Name == ""，该查询条件被忽略。
        /// 注意：一次仅能添加一个条件，范例：t => t.Name == "a" &amp;&amp; t.Mobile == "123"，不支持，将抛出异常</param>
        public static Expression<Func<TEntity, bool>> GetWhereIfNotEmptyExpression<TEntity>( Expression<Func<TEntity, bool>> predicate ) where TEntity : class {
            if ( predicate == null )
                return null;
            if( Lambda.GetConditionCount( predicate ) > 1 )
                throw new InvalidOperationException( string.Format( LibraryResource.OnlyOnePredicate, predicate ) );
            var value = predicate.Value();
            if( string.IsNullOrWhiteSpace( value.SafeString() ) )
                return null;
            return predicate;
        }
    }
}
