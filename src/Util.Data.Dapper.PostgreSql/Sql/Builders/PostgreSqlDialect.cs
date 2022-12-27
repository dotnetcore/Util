using Util.Data.Sql.Builders.Core;

namespace Util.Data.Sql.Builders {
    /// <summary>
    /// PostgreSql方言
    /// </summary>
    public class PostgreSqlDialect : DialectBase {
        /// <summary>
        /// 封闭构造方法
        /// </summary>
        private PostgreSqlDialect() {
        }

        /// <summary>
        /// PostgreSql方言实例
        /// </summary>
        public static readonly IDialect Instance = new PostgreSqlDialect();

        /// <inheritdoc />
        public override string GetOpeningIdentifier() {
            return "\"";
        }

        /// <inheritdoc />
        public override string GetClosingIdentifier() {
            return "\"";
        }

        /// <inheritdoc />
        public override string GetPrefix() {
            return "@";
        }
    }
}
