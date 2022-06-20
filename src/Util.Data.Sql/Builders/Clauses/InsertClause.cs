using System.Text;
using Util.Data.Sql.Builders.Caches;
using Util.Data.Sql.Builders.Core;
using Util.Data.Sql.Builders.Params;
using Util.Helpers;

namespace Util.Data.Sql.Builders.Clauses {
    /// <summary>
    /// Insert子句
    /// </summary>
    public class InsertClause : ClauseBase, IInsertClause {

        #region 字段

        /// <summary>
        /// Insert结果
        /// </summary>
        protected readonly StringBuilder InsertResult;
        /// <summary>
        /// Values结果
        /// </summary>
        protected readonly StringBuilder ValuesResult;
        /// <summary>
        /// 列缓存
        /// </summary>
        protected readonly IColumnCache ColumnCache;
        /// <summary>
        /// 参数管理器
        /// </summary>
        protected readonly IParameterManager ParameterManager;

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化Insert子句
        /// </summary>
        /// <param name="sqlBuilder">Sql生成器</param>
        /// <param name="insertResult">Insert结果</param>
        /// <param name="valuesResult">Values结果</param>
        public InsertClause( SqlBuilderBase sqlBuilder, StringBuilder insertResult = null, StringBuilder valuesResult = null ) : base( sqlBuilder ) {
            InsertResult = insertResult ?? new StringBuilder();
            ValuesResult = valuesResult ?? new StringBuilder();
            ColumnCache = sqlBuilder.ColumnCache;
            ParameterManager = sqlBuilder.ParameterManager;
        }

        #endregion

        #region Insert(设置插入的表和列名集合)

        /// <inheritdoc />
        public void Insert( string columns, string table = null ) {
            if ( InsertResult.Length == 0 ) {
                if ( table.IsEmpty() )
                    return;
                var tableItem = new TableItem( Dialect, table );
                tableItem.AppendTo( InsertResult );
                InsertResult.Append( "(" );
                InsertResult.Append( ColumnCache.GetSafeColumns( columns ) );
                InsertResult.Append( ")" );
                return;
            }
            AppendColumns( ColumnCache.GetSafeColumns( columns ) );
        }

        /// <summary>
        /// 添加列
        /// </summary>
        protected void AppendColumns( string columns ) {
            InsertResult.RemoveEnd( ")" );
            InsertResult.Append( "," );
            InsertResult.Append( columns );
            InsertResult.Append( ")" );
        }

        #endregion

        #region Values(设置插入的值集合)

        /// <inheritdoc />
        public void Values( params object[] values ) {
            if ( values == null )
                return;
            if ( ValuesResult.Length > 0 )
                ValuesResult.Append( "," );
            ValuesResult.Append( "(" );
            foreach ( var value in values ) {
                var paramName = ParameterManager.GenerateName();
                ValuesResult.AppendFormat( "{0},", paramName );
                ParameterManager.Add( paramName, value );
            }
            ValuesResult.RemoveEnd( "," ).Append( ")" );
        }

        #endregion

        #region AppendInsert(添加到Insert子句)

        /// <inheritdoc />
        public void AppendInsert( string sql, bool raw ) {
            if ( string.IsNullOrWhiteSpace( sql ) )
                return;
            if ( raw ) {
                InsertResult.Append( sql );
                return;
            }
            InsertResult.Append( ReplaceRawSql( sql ) );
        }

        #endregion

        #region AppendValues(添加到Values子句)

        /// <inheritdoc />
        public void AppendValues( string sql, bool raw ) {
            if ( string.IsNullOrWhiteSpace( sql ) )
                return;
            if ( raw ) {
                ValuesResult.Append( sql );
                return;
            }
            ValuesResult.Append( ReplaceRawSql( sql ) );
        }

        #endregion

        #region Validate(验证)

        /// <inheritdoc />
        public bool Validate() {
            return InsertResult.Length != 0;
        }

        #endregion

        #region AppendTo(添加到字符串生成器)

        /// <inheritdoc />
        public void AppendTo( StringBuilder builder ) {
            builder.CheckNull( nameof( builder ) );
            if ( Validate() == false )
                return;
            builder.Append( "Insert Into " );
            builder.Append( InsertResult );
            builder.AppendLine( " " );
            if ( ValuesResult.Length == 0 ) {
                builder.RemoveEnd( Common.Line );
                return;
            }
            builder.Append( "Values" );
            builder.Append( ValuesResult );
        }

        #endregion

        #region Clear(清理)

        /// <inheritdoc />
        public void Clear() {
            InsertResult.Clear();
            ValuesResult.Clear();
        }

        #endregion

        #region Clone(复制Insert子句)

        /// <inheritdoc />
        public virtual IInsertClause Clone( SqlBuilderBase builder ) {
            var insertResult = new StringBuilder();
            insertResult.Append( InsertResult );
            var valuesResult = new StringBuilder();
            valuesResult.Append( ValuesResult );
            return new InsertClause( builder, insertResult, valuesResult );
        }

        #endregion
    }
}
