using Util.Data.Sql.Builders;
using Util.Data.Sql.Builders.Caches;
using Util.Data.Sql.Builders.Params;

namespace Util.Data.Sql.Samples {
    /// <summary>
    /// 测试Sql生成器
    /// </summary>
    public class TestSqlBuilder : SqlBuilderBase {
        /// <summary>
        /// 初始化Sql生成器
        /// </summary>
        /// <param name="parameterManager">参数管理器</param>
        public TestSqlBuilder( IParameterManager parameterManager = null )
            : base( parameterManager ) {
        }

        /// <summary>
        /// 获取Sql方言
        /// </summary>
        protected override IDialect CreateDialect() {
            return TestDialect.Instance;
        }

        /// <summary>
        /// 获取列缓存
        /// </summary>
        protected override IColumnCache CreateColumnCache() {
            return TestColumnCache.Instance;
        }

        /// <summary>
        /// 创建Sql生成器
        /// </summary>
        public override ISqlBuilder New() {
            return new TestSqlBuilder( ParameterManager );
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
