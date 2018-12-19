using Util.Datas.Sql.Queries.Builders.Abstractions;
using Util.Datas.Sql.Queries.Builders.Clauses;
using Util.Datas.Sql.Queries.Builders.Core;

namespace Util.Datas.Dapper.MySql {
    /// <summary>
    /// MySql 表连接子句
    /// </summary>
    public class MySqlJoinClause : JoinClause {
        /// <summary>
        /// 初始化MySql 表连接子句
        /// </summary>
        /// <param name="dialect">方言</param>
        /// <param name="resolver">实体解析器</param>
        /// <param name="register">实体注册器</param>
        public MySqlJoinClause( IDialect dialect, IEntityResolver resolver, IEntityAliasRegister register )
            : base( dialect, resolver, register ) {
        }

        /// <summary>
        /// 创建连接项
        /// </summary>
        /// <param name="joinType">连接类型</param>
        /// <param name="table">表名</param>
        /// <param name="schema">架构名</param>
        /// <param name="alias">别名</param>
        protected override JoinItem CreateJoinItem( string joinType, string table, string schema, string alias ) {
            return new JoinItem( joinType, table, schema, alias, false, false );
        }
    }
}
