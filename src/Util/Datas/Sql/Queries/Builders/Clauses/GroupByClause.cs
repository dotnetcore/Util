using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Util.Datas.Sql.Queries.Builders.Abstractions;
using Util.Datas.Sql.Queries.Builders.Core;

namespace Util.Datas.Sql.Queries.Builders.Clauses {
    /// <summary>
    /// Group By子句
    /// </summary>
    public class GroupByClause : IGroupByClause {
        /// <summary>
        /// Sql方言
        /// </summary>
        private readonly IDialect _dialect;
        /// <summary>
        /// 实体解析器
        /// </summary>
        private readonly IEntityResolver _resolver;
        /// <summary>
        /// 实体注册器
        /// </summary>
        private readonly IEntityAliasRegister _register;
        /// <summary>
        /// 分组字段
        /// </summary>
        private readonly List<SqlItem> _group;
        /// <summary>
        /// 分组条件
        /// </summary>
        private string _having;

        /// <summary>
        /// 初始化分组子句
        /// </summary>
        /// <param name="dialect">Sql方言</param>
        /// <param name="resolver">实体解析器</param>
        /// <param name="register">实体别名注册器</param>
        public GroupByClause( IDialect dialect, IEntityResolver resolver, IEntityAliasRegister register ) {
            _dialect = dialect;
            _resolver = resolver;
            _register = register;
            _group = new List<SqlItem>();
        }

        /// <summary>
        /// 分组
        /// </summary>
        /// <param name="columns">分组字段</param>
        /// <param name="having">分组条件</param>
        public void GroupBy( string columns, string having = null ) {
            if( string.IsNullOrWhiteSpace( columns ) )
                return;
            _group.AddRange( columns.Split( ',' ).Select( item => new SqlItem( item ) ) );
            _having = having;
        }

        /// <summary>
        /// 分组
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="columns">分组字段</param>
        public void GroupBy<TEntity>( params Expression<Func<TEntity, object>>[] columns ) {
            if( columns == null )
                return;
            foreach ( var column in columns )
                GroupBy( column );
        }

        /// <summary>
        /// 分组
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="column">分组字段</param>
        /// <param name="having">分组条件</param>
        public void GroupBy<TEntity>( Expression<Func<TEntity, object>> column, string having = null ) {
            if( column == null )
                return;
            _group.Add( new SqlItem( _resolver.GetColumn( column ), _register.GetAlias( typeof( TEntity ) ) ) );
            _having = having;
        }

        /// <summary>
        /// 添加到GroupBy子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        public void AppendSql( string sql ) {
            if( string.IsNullOrWhiteSpace( sql ) )
                return;
            _group.Add( new SqlItem( sql, raw: true ) );
        }

        /// <summary>
        /// 是否存在分组
        /// </summary>
        public bool IsGroupBy => _group.Count > 0;

        /// <summary>
        /// 分组列表
        /// </summary>
        public string GroupByColumns => _group.Select( t => t.ToSql( _dialect ) ).Join();

        /// <summary>
        /// 获取Sql
        /// </summary>
        public string ToSql() {
            if( IsGroupBy == false )
                return null;
            var result = new StringBuilder();
            result.Append( $"Group By {GroupByColumns}" );
            if( string.IsNullOrWhiteSpace( _having ) )
                return result.ToString();
            result.Append( $" Having {_having}" );
            return result.ToString();
        }
    }
}
