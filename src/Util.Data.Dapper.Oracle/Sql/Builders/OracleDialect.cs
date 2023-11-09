using Util.Data.Sql.Builders;
using Util.Data.Sql.Builders.Core;

namespace Util.Data.Dapper.Sql.Builders; 

/// <summary>
/// Oracle方言
/// </summary>
public class OracleDialect : DialectBase {
    /// <summary>
    /// 封闭构造方法
    /// </summary>
    private OracleDialect() {
    }

    /// <summary>
    /// Oracle方言实例
    /// </summary>
    public static readonly IDialect Instance = new OracleDialect();

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
        return ":";
    }
}