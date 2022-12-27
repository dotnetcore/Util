using System;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using Util.Data.Queries;
using Util.Data.Queries.Conditions;

namespace Util.Data {
    /// <summary>
    /// 查询对象扩展
    /// </summary>
    public static class QueryableExtensions {

        #region Where(添加查询条件对象)

        /// <summary>
        /// 添加查询条件对象
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="source">源</param>
        /// <param name="condition">查询条件</param>
        public static IQueryable<TEntity> Where<TEntity>( this IQueryable<TEntity> source, ICondition<TEntity> condition ) where TEntity : class {
            source.CheckNull( nameof( source ) );
            condition.CheckNull( nameof( condition ) );
            var predicate = condition.GetCondition();
            if( predicate == null )
                return source;
            return source.Where( predicate );
        }

        #endregion

        #region WhereIf(根据规则添加查询条件)

        /// <summary>
        /// 根据规则添加查询条件
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="predicate">查询条件</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        public static IQueryable<TEntity> WhereIf<TEntity>( this IQueryable<TEntity> source, Expression<Func<TEntity, bool>> predicate, bool condition ) where TEntity : class {
            source.CheckNull( nameof( source ) );
            return condition ? source.Where( predicate ) : source;
        }

        #endregion

        #region WhereIfNotEmpty(根据规则添加查询条件)

        /// <summary>
        /// 根据规则添加查询条件
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="condition">查询条件,如果参数值为空，则忽略该查询条件，范例：t => t.Name == ""，该查询条件被忽略。
        /// 注意：一次仅能添加一个条件，范例：t => t.Name == "a" &amp;&amp; t.Mobile == "123"，不支持，将抛出异常</param>
        public static IQueryable<TEntity> WhereIfNotEmpty<TEntity>( this IQueryable<TEntity> source, Expression<Func<TEntity, bool>> condition ) where TEntity : class {
            source.CheckNull( nameof( source ) );
            return source.Where( new WhereIfNotEmptyCondition<TEntity>( condition ) );
        }

        #endregion

        #region OrIfNotEmpty(添加Or查询条件)

        /// <summary>
        /// 添加Or查询条件,对传入的条件使用Or连接
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="condition1">查询条件1,如果参数值为空，则忽略该查询条件，范例：t => t.Name == ""，该查询条件被忽略。
        /// 注意：一次仅能添加一个条件，范例：t => t.Name == "a" &amp;&amp; t.Mobile == "123"，不支持，将抛出异常</param>
        /// <param name="condition2">查询条件2,如果参数值为空，则忽略该查询条件，范例：t => t.Name == ""，该查询条件被忽略。
        /// 注意：一次仅能添加一个条件，范例：t => t.Name == "a" &amp;&amp; t.Mobile == "123"，不支持，将抛出异常</param>
        /// <param name="conditions">查询条件列表,如果参数值为空，则忽略该查询条件，范例：t => t.Name == ""，该查询条件被忽略。
        /// 注意：一次仅能添加一个条件，范例：t => t.Name == "a" &amp;&amp; t.Mobile == "123"，不支持，将抛出异常</param>
        public static IQueryable<TEntity> OrIfNotEmpty<TEntity>( this IQueryable<TEntity> source, Expression<Func<TEntity, bool>> condition1,
            Expression<Func<TEntity, bool>> condition2,params Expression<Func<TEntity, bool>>[] conditions ) where TEntity : class {
            source.CheckNull( nameof( source ) );
            return source.Where( new OrIfNotEmptyCondition<TEntity>( condition1, condition2, conditions ) );
        }

        #endregion

        #region Between(添加范围查询条件)

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="source">数据源</param>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="propertyExpression">属性表达式，范例：t => t.Age</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public static IQueryable<TEntity> Between<TEntity, TProperty>( this IQueryable<TEntity> source, Expression<Func<TEntity, TProperty>> propertyExpression, int? min, int? max, Boundary boundary = Boundary.Both ) where TEntity : class {
            source.CheckNull( nameof( source ) );
            return source.Where( new IntSegmentCondition<TEntity, TProperty>( propertyExpression, min, max, boundary ) );
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="source">数据源</param>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="propertyExpression">属性表达式，范例：t => t.Age</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public static IQueryable<TEntity> Between<TEntity, TProperty>( this IQueryable<TEntity> source, Expression<Func<TEntity, TProperty>> propertyExpression, double? min, double? max, Boundary boundary = Boundary.Both ) where TEntity : class {
            source.CheckNull( nameof( source ) );
            return source.Where( new DoubleSegmentCondition<TEntity, TProperty>( propertyExpression, min, max, boundary ) );
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="source">数据源</param>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="propertyExpression">属性表达式，范例：t => t.Age</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="boundary">包含边界</param>
        public static IQueryable<TEntity> Between<TEntity, TProperty>( this IQueryable<TEntity> source, Expression<Func<TEntity, TProperty>> propertyExpression, decimal? min, decimal? max, Boundary boundary = Boundary.Both ) where TEntity : class {
            source.CheckNull( nameof( source ) );
            return source.Where( new DecimalSegmentCondition<TEntity, TProperty>( propertyExpression, min, max, boundary ) );
        }

        /// <summary>
        /// 添加范围查询条件
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="source">数据源</param>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="propertyExpression">属性表达式，范例：t => t.Time</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="includeTime">是否包含时间</param>
        /// <param name="boundary">包含边界</param>
        public static IQueryable<TEntity> Between<TEntity, TProperty>( this IQueryable<TEntity> source, Expression<Func<TEntity, TProperty>> propertyExpression, DateTime? min, DateTime? max, bool includeTime = true, Boundary boundary = Boundary.Both ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( includeTime )
                return source.Where( new DateTimeSegmentCondition<TEntity, TProperty>( propertyExpression, min, max, boundary ) );
            return source.Where( new DateSegmentCondition<TEntity, TProperty>( propertyExpression, min, max, boundary ) );
        }

        #endregion

        #region OrderBy(排序)

        /// <summary>
        /// 排序,说明:如果未设置排序条件,则使用Id排序
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="source">源</param>
        /// <param name="parameter">分页参数</param>
        /// <param name="defaultOrder">默认排序属性,如果未设置排序条件,则使用该排序属性,范例: "Id"</param>
        public static IQueryable<TEntity> OrderBy<TEntity>( this IQueryable<TEntity> source, IPage parameter,string defaultOrder = null ) where TEntity : class {
            source.CheckNull( nameof( source ) );
            parameter.CheckNull( nameof( parameter ) );
            InitOrder( source, parameter, defaultOrder );
            return parameter.Order.IsEmpty() ? source : source.OrderBy( parameter.Order );
        }

        /// <summary>
        /// 初始化排序
        /// </summary>
        private static void InitOrder<TEntity>( IQueryable<TEntity> source, IPage parameter, string defaultOrder ) {
            if( parameter.Order.IsEmpty() == false )
                return;
            var expression = source.Expression.SafeString();
            if( expression.Contains( ".OrderBy(" ) || expression.Contains( ".OrderByDescending(" ) )
                return;
            if ( defaultOrder.IsEmpty() )
                return;
            parameter.Order = defaultOrder;
        }

        #endregion
    }
}
