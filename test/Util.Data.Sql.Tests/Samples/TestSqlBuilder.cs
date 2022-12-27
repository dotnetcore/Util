using Util.Data.Sql.Builders;
using Util.Data.Sql.Builders.Caches;
using Util.Data.Sql.Builders.Params;

namespace Util.Data.Sql.Tests.Samples {
    /// <summary>
    /// 测试Sql生成器
    /// </summary>
    public class TestSqlBuilder : SqlBuilderBase {
        /// <summary>
        /// Sql方言
        /// </summary>
        private readonly IDialect _dialect;
        /// <summary>
        /// 列缓存
        /// </summary>
        private readonly IColumnCache _columnCache;

        /// <summary>
        /// 初始化Sql生成器
        /// </summary>
        public TestSqlBuilder( IDialect dialect = null, IColumnCache columnCache = null, IParameterManager parameterManager = null )
            : base( parameterManager ) {
            _dialect = dialect;
            _columnCache = columnCache;
        }

        /// <summary>
        /// 获取Sql方言
        /// </summary>
        protected override IDialect CreateDialect() {
            if ( _dialect != null )
                return _dialect;
            return TestDialect.Instance;
        }

        /// <summary>
        /// 获取列缓存
        /// </summary>
        protected override IColumnCache CreateColumnCache() {
            if ( _columnCache != null )
                return _columnCache;
            return TestColumnCache.Instance;
        }

        /// <summary>
        /// 创建Sql生成器
        /// </summary>
        public override ISqlBuilder New() {
            return new TestSqlBuilder( Dialect,ColumnCache, ParameterManager );
        }

        /// <summary>
        /// 复制Sql生成器
        /// </summary>
        public override ISqlBuilder Clone() {
            var result = new TestSqlBuilder();
            result.Clone( this );
            return result;
        }
    }
}
