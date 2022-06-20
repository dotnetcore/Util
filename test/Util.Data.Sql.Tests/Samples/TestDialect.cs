using Util.Data.Sql.Builders;
using Util.Data.Sql.Builders.Core;

namespace Util.Data.Sql.Tests.Samples {
    /// <summary>
    /// 测试方言
    /// </summary>
    public class TestDialect : DialectBase {
        /// <summary>
        /// 封闭构造方法
        /// </summary>
        private TestDialect() {
        }

        /// <summary>
        /// 测试方言实例
        /// </summary>
        public static readonly IDialect Instance = new TestDialect();

        /// <summary>
        /// 获取起始转义标识符
        /// </summary>
        public override string GetOpeningIdentifier() {
            return "[";
        }

        /// <summary>
        /// 获取结束转义标识符
        /// </summary>
        public override string GetClosingIdentifier() {
            return "]";
        }

        /// <summary>
        /// 获取参数前缀
        /// </summary>
        public override string GetPrefix() {
            return "@";
        }
    }
}
