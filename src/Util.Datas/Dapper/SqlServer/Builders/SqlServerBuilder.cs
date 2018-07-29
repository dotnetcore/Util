using System.Text;
using Util.Datas.Sql.Queries.Builders;

namespace Util.Datas.Dapper.SqlServer.Builders {
    /// <summary>
    /// Sql Server Sql生成器
    /// </summary>
    public class SqlServerBuilder : Util.Datas.Dapper.Core.SqlBuilderBase {
        /// <summary>
        /// 获取参数前缀
        /// </summary>
        protected override string GetPrefix() {
            return "@";
        }

        /// <summary>
        /// 创建Sql生成器
        /// </summary>
        public override ISqlBuilder New() {
            return new SqlServerBuilder {
                Tag = $"{Tag}{++ChildBuilderCount}"
            };
        }

        /// <summary>
        /// 获取安全名称
        /// </summary>
        protected override string SafeName( string name ) {
            if ( string.IsNullOrWhiteSpace( name ) )
                return string.Empty;
            if ( name == "*" )
                return name;
            name = name.Trim().TrimStart( '[' ).TrimEnd( ']' );
            return $"[{name}]";
        }

        /// <summary>
        /// 创建Sql语句
        /// </summary>
        protected override void CreateSql( StringBuilder result ) {
            result.AppendLine( GetSelect() );
            result.AppendLine( GetFrom() );
            result.AppendLine( GetWhere() );
        }
    }
}
