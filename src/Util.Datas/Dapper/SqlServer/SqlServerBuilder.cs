using System.Text;
using Util.Datas.Matedatas;
using Util.Datas.Sql.Queries.Builders.Abstractions;

namespace Util.Datas.Dapper.SqlServer {
    /// <summary>
    /// Sql Server Sql生成器
    /// </summary>
    public class SqlServerBuilder : Util.Datas.Dapper.Core.SqlBuilderBase {
        /// <summary>
        /// 初始化Sql生成器
        /// </summary>
        /// <param name="matedata">实体元数据解析器</param>
        public SqlServerBuilder( IEntityMatedata matedata = null ) : base( matedata ) {
        }

        /// <summary>
        /// 获取参数前缀
        /// </summary>
        protected override string GetPrefix() {
            return "@";
        }

        /// <summary>
        /// 获取Sql方言
        /// </summary>
        protected override IDialect GetDialect() {
            return new SqlServerDialect();
        }

        /// <summary>
        /// 创建Sql生成器
        /// </summary>
        public override ISqlBuilder New() {
            return new SqlServerBuilder( EntityMatedata ) {
                Tag = $"{Tag}{++ChildBuilderCount}"
            };
        }

        /// <summary>
        /// 获取安全名称
        /// </summary>
        protected override string SafeName( string name ) {
            if( string.IsNullOrWhiteSpace( name ) )
                return string.Empty;
            if( name == "*" )
                return name;
            name = name.Trim().TrimStart( '[' ).TrimEnd( ']' );
            return $"[{name}]";
        }

        /// <summary>
        /// 创建Sql语句
        /// </summary>
        protected override void CreateSql( StringBuilder result ) {
            result.AppendLine( $"{GetSelect()} " );
            result.AppendLine( $"{GetFrom()} " );
            result.AppendLine( $"{GetJoin()} " );
            result.AppendLine( GetWhere() );
        }
    }
}
