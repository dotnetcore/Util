using Util.Data.Sql.Builders;
using Util.Data.Sql.Builders.Params;

namespace Util.Data.Dapper.Sql.Builders;

/// <summary>
/// Oracle Sql参数管理器
/// </summary>
public class OracleParameterManager : ParameterManager {
    /// <summary>
    /// 初始化Oracle Sql参数管理器
    /// </summary>
    /// <param name="dialect">Sql方言</param>
    public OracleParameterManager( IDialect dialect ) : base( dialect ) {
    }

    /// <summary>
    /// 初始化Oracle Sql参数管理器
    /// </summary>
    /// <param name="manager">Sql参数管理器</param>
    public OracleParameterManager( ParameterManager manager ) : base( manager ) {
    }

    /// <inheritdoc />
    public override string GenerateName() {
        var result = $"{Dialect.GetPrefix()}p_{ParamIndex}";
        ParamIndex++;
        return result;
    }
}