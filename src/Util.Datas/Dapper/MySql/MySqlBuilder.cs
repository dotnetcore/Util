using System.Text;
using Util.Datas.Matedatas;
using Util.Datas.Sql.Queries.Builders.Abstractions;
using Util.Datas.Sql.Queries.Builders.Core;

namespace Util.Datas.Dapper.MySql {
    /// <summary>
    /// MySql Sql生成器
    /// </summary>
    public class MySqlBuilder : SqlBuilderBase {
        /// <summary>
        /// 初始化Sql生成器
        /// </summary>
        /// <param name="matedata">实体元数据解析器</param>
        /// <param name="parameterManager">参数管理器</param>
        public MySqlBuilder( IEntityMatedata matedata = null, IParameterManager parameterManager = null ) : base( matedata, parameterManager ) {
        }

        /// <summary>
        /// 获取Sql方言
        /// </summary>
        protected override IDialect GetDialect() {
            return new MySqlDialect();
        }

        /// <summary>
        /// 创建Sql生成器
        /// </summary>
        public override ISqlBuilder New() {
            return new MySqlBuilder( EntityMatedata, ParameterManager );
        }

        /// <summary>
        /// 创建From子句
        /// </summary>
        protected override IFromClause CreateFromClause() {
            return new MySqlFromClause( GetDialect(), EntityResolver, AliasRegister );
        }

        /// <summary>
        /// 创建Join子句
        /// </summary>
        protected override IJoinClause CreateJoinClause() {
            return new MySqlJoinClause( GetDialect(), EntityResolver, AliasRegister );
        }

        /// <summary>
        /// 创建分页Sql
        /// </summary>
        protected override void CreatePagerSql( StringBuilder result ) {
            AppendSelect( result );
            AppendFrom( result );
            AppendSql( result, GetJoin() );
            AppendSql( result, GetWhere() );
            AppendSql( result, GetGroupBy() );
            AppendSql( result, GetOrderBy() );
            result.Append( $"Limit {GetSkipCountParam()}, {GetPageSizeParam()}" );
        }
    }
}