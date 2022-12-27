using System;
using System.Collections.Generic;
using System.Linq;
using Util.Data.Queries;

namespace Util.Data {
    /// <summary>
    /// 分页集合
    /// </summary>
    /// <typeparam name="T">元素类型</typeparam>
    public class PageList<T> {
        /// <summary>
        /// 初始化分页集合
        /// </summary>
        public PageList() : this( 0 ) {
        }

        /// <summary>
        /// 初始化分页集合
        /// </summary>
        /// <param name="data">内容</param>
        public PageList( IEnumerable<T> data = null )
            : this( 0, data ) {
        }

        /// <summary>
        /// 初始化分页集合
        /// </summary>
        /// <param name="totalCount">总行数</param>
        /// <param name="data">内容</param>
        public PageList( int totalCount, IEnumerable<T> data = null )
            : this( 1, 20, totalCount, data ) {
        }

        /// <summary>
        /// 初始化分页集合
        /// </summary>
        /// <param name="page">页索引</param>
        /// <param name="pageSize">每页显示行数</param>
        /// <param name="totalCount">总行数</param>
        /// <param name="data">内容</param>
        public PageList( int page, int pageSize, int totalCount, IEnumerable<T> data = null )
            : this( page, pageSize, totalCount, "", data ) {
        }

        /// <summary>
        /// 初始化分页集合
        /// </summary>
        /// <param name="page">页索引</param>
        /// <param name="pageSize">每页显示行数</param>
        /// <param name="totalCount">总行数</param>
        /// <param name="order">排序条件</param>
        /// <param name="data">内容</param>
        public PageList( int page, int pageSize, int totalCount, string order, IEnumerable<T> data = null ) {
            Data = data?.ToList() ?? new List<T>();
            var pager = new Pager( page, pageSize, totalCount );
            Total = pager.Total;
            PageCount = pager.GetPageCount();
            Page = pager.Page;
            PageSize = pager.PageSize;
            Order = order;
        }

        /// <summary>
        /// 初始化分页集合
        /// </summary>
        /// <param name="pager">查询对象</param>
        /// <param name="data">内容</param>
        public PageList( IPage pager, IEnumerable<T> data = null )
            : this( pager.Page, pager.PageSize, pager.Total, pager.Order, data ) {
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
        public int Total { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// 排序条件
        /// </summary>
        public string Order { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public List<T> Data { get; init; }

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index">索引</param>
        public T this[int index] {
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
        /// 转换分页集合
        /// </summary>
        /// <typeparam name="TResult">目标元素类型</typeparam>
        /// <param name="converter">转换方法</param>
        public PageList<TResult> Convert<TResult>( Func<T, TResult> converter ) {
            return Convert( Data.Select( converter ) );
        }

        /// <summary>
        /// 转换分页集合
        /// </summary>
        /// <param name="data">内容</param>
        public PageList<TResult> Convert<TResult>( IEnumerable<TResult> data ) {
            return new( Page, PageSize, Total, Order, data );
        }
    }
}
