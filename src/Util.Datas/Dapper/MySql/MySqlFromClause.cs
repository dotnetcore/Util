using Util.Datas.Sql;
using Util.Datas.Sql.Builders;
using Util.Datas.Sql.Builders.Clauses;
using Util.Datas.Sql.Builders.Core;
using Util.Datas.Sql.Matedatas;

namespace Util.Datas.Dapper.MySql {
    /// <summary>
    /// MySql From子句
    /// </summary>
    public class MySqlFromClause : FromClause {
        /// <summary>
        /// 初始化From子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="dialect">方言</param>
        /// <param name="resolver">实体解析器</param>
        /// <param name="register">实体别名注册器</param>
        /// <param name="tableDatabase">表数据库</param>
        /// <param name="table">表</param>
        public MySqlFromClause( ISqlBuilder builder, IDialect dialect, IEntityResolver resolver, IEntityAliasRegister register, ITableDatabase tableDatabase, SqlItem table = null )
            : base( builder, dialect, resolver, register, tableDatabase, table ) {
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

        /// <summary>
        /// 复制From子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="register">实体别名注册器</param>
        public override IFromClause Clone( ISqlBuilder builder, IEntityAliasRegister register ) {
            if( register != null )
                register.FromType = Register.FromType;
            return new MySqlFromClause( builder, Dialect, Resolver, register, TableDatabase, Table );
        }
    }
}
