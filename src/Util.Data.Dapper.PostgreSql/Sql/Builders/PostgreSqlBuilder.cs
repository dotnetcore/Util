using Util.Data.Sql.Builders.Caches;
using Util.Data.Sql.Builders.Params;

namespace Util.Data.Sql.Builders {
    /// <summary>
    /// PostgreSql Sql生成器
    /// </summary>
    public class PostgreSqlBuilder : SqlBuilderBase {
        /// <summary>
        /// 初始化PostgreSql Sql生成器
        /// </summary>
        /// <param name="parameterManager">Sql参数管理器</param>
        public PostgreSqlBuilder( IParameterManager parameterManager = null )
            : base( parameterManager ) {
        }

        /// <inheritdoc />
        protected override IDialect CreateDialect() {
            return PostgreSqlDialect.Instance;
        }

        /// <inheritdoc />
        protected override IColumnCache CreateColumnCache() {
            return PostgreSqlColumnCache.Instance;
        }

        /// <inheritdoc />
        public override ISqlBuilder New() {
            return new PostgreSqlBuilder( ParameterManager );
        }

        /// <inheritdoc />
        public override ISqlBuilder Clone() {
            var result = new PostgreSqlBuilder();
            result.Clone( this );
            return result;
        }
    }
}
