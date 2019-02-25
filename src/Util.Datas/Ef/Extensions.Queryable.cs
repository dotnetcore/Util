using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Util.Datas.Queries.Internal;
using Util.Domains.Repositories;

namespace Util.Datas.Ef {
    /// <summary>
    /// 查询扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 转换为分页列表，包含排序分页操作
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="pager">分页对象</param>
        public static async Task<PagerList<TEntity>> ToPagerListAsync<TEntity>( this IQueryable<TEntity> source, IPager pager ) {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( pager == null )
                throw new ArgumentNullException( nameof( pager ) );
            source = await source.PageAsync( pager );
            return new PagerList<TEntity>( pager, await source.ToListAsync() );
        }

        /// <summary>
        /// 分页，包含排序
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="pager">分页对象</param>
        public static async Task<IQueryable<TEntity>> PageAsync<TEntity>( this IQueryable<TEntity> source, IPager pager ) {
            if( source == null )
                throw new ArgumentNullException( nameof( source ) );
            if( pager == null )
                throw new ArgumentNullException( nameof( pager ) );
            Helper.InitOrder( source, pager );
            if( pager.TotalCount <= 0 )
                pager.TotalCount = await source.CountAsync();
            var orderedQueryable = Helper.GetOrderedQueryable( source, pager );
            if( orderedQueryable == null )
                throw new ArgumentException( "必须设置排序字段" );
            return orderedQueryable.Skip( pager.GetSkipCount() ).Take( pager.PageSize );
        }
    }
}
