using Util.Data.Sql.Builders.Caches;
using Util.Data.Sql.Builders.Params;

namespace Util.Data.Sql.Builders {
    /// <summary>
    /// Sql Server Sql生成器
    /// </summary>
    public class SqlServerBuilder : SqlBuilderBase {
        /// <summary>
        /// 初始化Sql Server Sql生成器
        /// </summary>
        /// <param name="parameterManager">Sql参数管理器</param>
        public SqlServerBuilder( IParameterManager parameterManager = null )
            : base( parameterManager ) {
        }

        /// <inheritdoc />
        protected override IDialect CreateDialect() {
            return SqlServerDialect.Instance;
        }

        /// <inheritdoc />
        protected override IColumnCache CreateColumnCache() {
            return SqlServerColumnCache.Instance;
        }

        /// <inheritdoc />
        public override ISqlBuilder New() {
            return new SqlServerBuilder( ParameterManager );
        }

        /// <inheritdoc />
        public override ISqlBuilder Clone() {
            var result = new SqlServerBuilder();
            result.Clone( this );
            return result;
        }
    }
}
