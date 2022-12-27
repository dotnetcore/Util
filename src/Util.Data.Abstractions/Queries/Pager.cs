namespace Util.Data.Queries {
    /// <summary>
    /// 分页参数
    /// </summary>
    public class Pager : IPage {
        /// <summary>
        /// 初始化分页参数
        /// </summary>
        public Pager()
            : this( 1 ) {
        }

        /// <summary>
        /// 初始化分页参数
        /// </summary>
        /// <param name="page">页索引</param>
        /// <param name="pageSize">每页显示行数,默认20</param> 
        /// <param name="order">排序条件</param>
        public Pager( int page, int pageSize, string order )
            : this( page, pageSize, 0, order ) {
        }

        /// <summary>
        /// 初始化分页参数
        /// </summary>
        /// <param name="page">页索引</param>
        /// <param name="pageSize">每页显示行数,默认20</param> 
        /// <param name="total">总行数</param>
        /// <param name="order">排序条件</param>
        public Pager( int page, int pageSize = 20, int total = 0, string order = "" ) {
            Page = page;
            PageSize = pageSize;
            Total = total;
            Order = order;
        }

        private int _pageIndex;
        /// <summary>
        /// 页索引，即第几页，从1开始
        /// </summary>
        public int Page {
            get {
                if( _pageIndex <= 0 )
                    _pageIndex = 1;
                return _pageIndex;
            }
            set => _pageIndex = value;
        }

        /// <summary>
        /// 每页显示行数
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 总行数
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// 获取总页数
        /// </summary>
        public int GetPageCount() {
            if ( ( Total % PageSize ) == 0 )
                return Total / PageSize;
            return ( Total / PageSize ) + 1;
        }

        /// <summary>
        /// 获取跳过的行数
        /// </summary>
        public int GetSkipCount() {
            return PageSize * ( Page - 1 );
        }

        /// <summary>
        /// 排序条件
        /// </summary>
        public string Order { get; set; }

        /// <summary>
        /// 起始行数
        /// </summary>
        public int GetStartNumber() {
            return ( Page - 1 ) * PageSize + 1;
        }
        /// <summary>
        /// 结束行数
        /// </summary>
        public int GetEndNumber() {
            return Page * PageSize;
        }
    }
}
