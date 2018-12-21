using Util.Datas.Sql.Queries.Builders.Abstractions;
using Util.Datas.Sql.Queries.Builders.Clauses;
using Util.Datas.Sql.Queries.Builders.Core;

namespace Util.Datas.Dapper.MySql {
    /// <summary>
    /// MySql From子句
    /// </summary>
    public class MySqlFromClause : FromClause {
        /// <summary>
        /// 初始化From子句
        /// </summary>
        /// <param name="dialect">方言</param>
        /// <param name="resolver">实体解析器</param>
        /// <param name="register">实体别名注册器</param>
        public MySqlFromClause( IDialect dialect, IEntityResolver resolver, IEntityAliasRegister register )
            : base( dialect, resolver, register ) {
        }

        /// <summary>
        /// 创建Sql项
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="schema">架构名</param>
        /// <param name="alias">别名</param>
        protected override SqlItem CreateSqlItem( string table, string schema, string alias ) {
            return new SqlItem( table, schema, alias, false, false );
        }
    }
}
