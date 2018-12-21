using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using Util.Datas.Queries;
using Util.Datas.Queries.Criterias;
using Util.Datas.Queries.Internal;
using Util.Domains.Repositories;

namespace Util {
    /// <summary>
    /// 查询扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 添加查询条件
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="criteria">查询条件对象</param>
        public static IQueryable<TEntity> Where<TEntity>( this IQueryable<TEntity> source, ICriteria<TEntity> criteria ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( criteria == null )
                throw new ArgumentNullException( nameof( criteria ) );
            var predicate = criteria.GetPredicate();
            if( predicate == null )
                return source;
            return source.Where( predicate );
        }

        /// <summary>
        /// 添加查询条件
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="predicate">查询条件</param>
        /// <param name="condition">该值为true时添加查询条件，否则忽略</param>
        public static IQueryable<TEntity> WhereIf<TEntity>( this IQueryable<TEntity> source, Expression<Func<TEntity, bool>> predicate, bool condition ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( condition == false )
                return source;
            return source.Where( predicate );
        }

        /// <summary>
        /// 添加查询条件
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="predicate">查询条件,如果参数值为空，则忽略该查询条件，范例：t => t.Name == ""，该查询条件被忽略。
        /// 注意：一次仅能添加一个条件，范例：t => t.Name == "a" &amp;&amp; t.Mobile == "123"，不支持，将抛出异常</param>
        public static IQueryable<TEntity> WhereIfNotEmpty<TEntity>( this IQueryable<TEntity> source, Expression<Func<TEntity, bool>> predicate ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            predicate = Helper.GetWhereIfNotEmptyExpression( predicate );
            if( predicate == null )
                return source;
            return source.Where( predicate );
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
        public static IQueryable<TEntity> Between<TEntity, TProperty>( this IQueryable<TEntity> source, Expression<Func<TEntity, TProperty>> propertyExpression, int? min, int? max, Boundary boundary = Boundary.Both ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            return source.Where( new IntSegmentCriteria<TEntity, TProperty>( propertyExpression, min, max, boundary ) );
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
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            return source.Where( new DoubleSegmentCriteria<TEntity, TProperty>( propertyExpression, min, max, boundary ) );
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
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            return source.Where( new DecimalSegmentCriteria<TEntity, TProperty>( propertyExpression, min, max, boundary ) );
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
        public static IQueryable<TEntity> Between<TEntity, TProperty>( this IQueryable<TEntity> source, Expression<Func<TEntity, TProperty>> propertyExpression, DateTime? min, DateTime? max, bool includeTime = true, Boundary? boundary = null ) where TEntity : class {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( includeTime )
                return source.Where( new DateTimeSegmentCriteria<TEntity, TProperty>( propertyExpression, min, max, boundary ?? Boundary.Both ) );
            return source.Where( new DateSegmentCriteria<TEntity, TProperty>( propertyExpression, min, max, boundary ?? Boundary.Left ) );
        }

        /// <summary>
        /// 分页，包含排序
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="pager">分页对象</param>
        public static IQueryable<TEntity> Page<TEntity>( this IQueryable<TEntity> source, IPager pager ) {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( pager == null )
                throw new ArgumentNullException( nameof( pager ) );
            InitOrder( source, pager );
            if( pager.TotalCount <= 0 )
                pager.TotalCount = source.Count();
            var orderedQueryable = GetOrderedQueryable( source, pager );
            if( orderedQueryable == null )
                throw new ArgumentException("必须设置排序字段");
            return orderedQueryable.Skip( pager.GetSkipCount() ).Take( pager.PageSize );
        }

        /// <summary>
        /// 初始化排序
        /// </summary>
        private static void InitOrder<TEntity>( this IQueryable<TEntity> source, IPager pager ) {
            if ( string.IsNullOrWhiteSpace( pager.Order ) == false )
                return;
            if ( source.Expression.SafeString().Contains( ".OrderBy(" ) )
                return;
            pager.Order = "Id";
        }

        /// <summary>
        /// 获取排序查询对象
        /// </summary>
        private static IOrderedQueryable<TEntity> GetOrderedQueryable<TEntity>( this IQueryable<TEntity> source, IPager pager ) {
            if( string.IsNullOrWhiteSpace( pager.Order ) )
                return source as IOrderedQueryable<TEntity>;
            return source.OrderBy( pager.Order );
        }

        /// <summary>
        /// 转换为分页列表，包含排序分页操作
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="pager">分页对象</param>
        public static PagerList<TEntity> ToPagerList<TEntity>( this IQueryable<TEntity> source, IPager pager ) {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( pager == null )
                throw new ArgumentNullException( nameof( pager ) );
            return new PagerList<TEntity>( pager, source.Page( pager ).ToList() );
        }
    }
}
