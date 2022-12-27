using System.Text;
using Util.Data.Queries;
using Util.Data.Sql.Builders.Params;

namespace Util.Data.Sql.Builders.Clauses {
    /// <summary>
    /// 结束子句
    /// </summary>
    public class EndClause : ClauseBase, IEndClause {

        #region 字段

        /// <summary>
        /// 结束子句结果
        /// </summary>
        protected readonly StringBuilder Result;
        /// <summary>
        /// 跳过行数参数名
        /// </summary>
        protected string OffsetParam;
        /// <summary>
        /// 限制行数参数名
        /// </summary>
        protected string LimitParam;
        /// <summary>
        /// 参数管理器
        /// </summary>
        protected IParameterManager ParameterManager;
        /// <summary>
        /// 分页
        /// </summary>
        protected IPage Pager;

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化结束子句
        /// </summary>
        /// <param name="sqlBuilder">Sql生成器</param>
        /// <param name="result">结束子句结果</param>
        /// <param name="offsetParam">跳过行数参数名</param>
        /// <param name="limitParam">限制行数参数名</param>
        /// <param name="pager">分页</param>
        public EndClause( SqlBuilderBase sqlBuilder, StringBuilder result = null, string offsetParam = null, string limitParam = null, IPage pager = null ) : base( sqlBuilder ) {
            Result = result ?? new StringBuilder();
            OffsetParam = offsetParam;
            LimitParam = limitParam;
            Pager = pager;
            ParameterManager = sqlBuilder.ParameterManager;
        }

        #endregion

        #region Page(设置分页)

        /// <inheritdoc />
        public void Page( IPage page ) {
            if( page == null )
                return;
            Pager = page;
            Skip( page.GetSkipCount() );
            Take( page.PageSize );
        }

        #endregion

        #region Skip(设置跳过行数)

        /// <inheritdoc />
        public void Skip( int count ) {
            var param = GetOffsetParam();
            ParameterManager.Add( param, count );
        }

        /// <summary>
        /// 获取跳过行数参数名
        /// </summary>
        protected string GetOffsetParam() {
            if( OffsetParam.IsEmpty() == false )
                return OffsetParam;
            OffsetParam = CreateOffsetParam();
            return OffsetParam;
        }

        /// <summary>
        /// 创建跳过行数参数名
        /// </summary>
        private string CreateOffsetParam() {
            var result = ParameterManager.GenerateName();
            ParameterManager.Add( result, 0 );
            return result;
        }

        #endregion

        #region Take(设置获取行数)

        /// <inheritdoc />
        public void Take( int count ) {
            var param = GetLimitParam();
            ParameterManager.Add( param, count );
        }

        /// <summary>
        /// 获取限制行数的参数名
        /// </summary>
        protected string GetLimitParam() {
            if( LimitParam.IsEmpty() == false )
                return LimitParam;
            LimitParam = ParameterManager.GenerateName();
            return LimitParam;
        }

        #endregion

        #region AppendSql(添加到结束位置)

        /// <summary>
        /// 添加到结束位置
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="raw">是否原样添加</param>
        public void AppendSql( string sql, bool raw ) {
            if( string.IsNullOrWhiteSpace( sql ) )
                return;
            if( raw ) {
                Result.Append( sql );
                return;
            }
            Result.Append( ReplaceRawSql( sql ) );
        }

        #endregion

        #region Validate(验证)

        /// <inheritdoc />
        public bool Validate() {
            if ( Result.Length > 0 )
                return true;
            if ( LimitParam.IsEmpty() == false )
                return true;
            return false;
        }

        #endregion

        #region AppendTo(添加到字符串生成器)

        /// <inheritdoc />
        public void AppendTo( StringBuilder builder ) {
            builder.CheckNull( nameof( builder ) );
            if( Validate() == false )
                return;
            AppendLimit( builder );
            builder.Append( Result );
        }

        #endregion

        #region AppendLimit(添加行限制)

        /// <summary>
        /// 添加行限制
        /// </summary>
        /// <param name="builder">字符串生成器</param>
        protected virtual void AppendLimit( StringBuilder builder ) {
            if( LimitParam.IsEmpty() )
                return;
            builder.AppendFormat( "Limit {0} OFFSET {1}", GetLimitParam(), GetOffsetParam() );
        }

        #endregion

        #region ClearPage(清理分页)

        /// <inheritdoc />
        public void ClearPage() {
            OffsetParam = null;
            LimitParam = null;
            Pager = null;
        }

        #endregion

        #region Clear(清理)

        /// <inheritdoc />
        public void Clear() {
            Result.Clear();
            ClearPage();
        }

        #endregion

        #region Clone(复制结束子句)

        /// <inheritdoc />
        public virtual IEndClause Clone( SqlBuilderBase builder ) {
            var result = new StringBuilder();
            result.Append( Result );
            return new EndClause( builder, result, OffsetParam, LimitParam, Pager );
        }

        #endregion
    }
}
