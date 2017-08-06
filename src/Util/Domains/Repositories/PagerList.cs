using System;
using System.Collections.Generic;
using System.Linq;

namespace Util.Domains.Repositories {
    /// <summary>
    /// 分页集合
    /// </summary>
    /// <typeparam name="T">元素类型</typeparam>
    [Serializable]
    public class PagerList<T> : IPagerBase {
        /// <summary>
        /// 初始化分页集合
        /// </summary>
        public PagerList() : this( 0 ) {
        }

        /// <summary>
        /// 初始化分页集合
        /// </summary>
        /// <param name="totalCount">总行数</param>
        public PagerList( int totalCount )
            : this( 1, 20, totalCount ) {
        }

        /// <summary>
        /// 初始化分页集合
        /// </summary>
        /// <param name="page">页索引</param>
        /// <param name="pageSize">每页显示行数</param>
        /// <param name="totalCount">总行数</param>
        public PagerList( int page, int pageSize, int totalCount )
            : this( page, pageSize, totalCount, "" ) {
        }

        /// <summary>
        /// 初始化分页集合
        /// </summary>
        /// <param name="page">页索引</param>
        /// <param name="pageSize">每页显示行数</param>
        /// <param name="totalCount">总行数</param>
        /// <param name="order">排序条件</param>
        public PagerList( int page, int pageSize, int totalCount, string order ) {
            Data = new List<T>();
            var pager = new Pager( page, pageSize, totalCount );
            TotalCount = pager.TotalCount;
            PageCount = pager.GetPageCount();
            Page = pager.Page;
            PageSize = pager.PageSize;
            Order = order;
        }

        /// <summary>
        /// 初始化分页集合
        /// </summary>
        /// <param name="pager">查询对象</param>
        public PagerList( IPager pager )
            : this( pager.Page, pager.PageSize, pager.TotalCount, pager.Order ) {
        }

        /// <summary>
        /// 页索引，即第几页，从1开始
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 每页显示行数
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 总行数
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// 排序条件
        /// </summary>
        public string Order { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Count => Data.Count;

        /// <summary>
        /// 内容
        /// </summary>
        public List<T> Data { get; set; }

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index">索引</param>
        public T this[ int index ] {
            get => Data[index];
            set => Data[index] = value;
        }

        /// <summary>
        /// 添加元素
        /// </summary>
        /// <param name="item">元素</param>
        public void Add( T item ) {
            Data.Add( item );
        }

        /// <summary>
        /// 添加元素集合
        /// </summary>
        /// <param name="collection">元素集合</param>
        public void AddRange( IEnumerable<T> collection ) {
            Data.AddRange( collection );
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void Clear() {
            Data.Clear();
        }

        /// <summary>
        /// 转换分页集合的元素类型
        /// </summary>
        /// <typeparam name="TResult">目标元素类型</typeparam>
        /// <param name="converter">转换方法</param>
        public PagerList<TResult> Convert<TResult>( Func<T, TResult> converter ) {
            var result = new PagerList<TResult>( Page, PageSize, TotalCount, Order );
            result.AddRange( this.Data.Select( converter ) );
            return result;
        }
    }
}
