using Util.Data.Sql;
using Util.Data.Sql.Builders;
using Util.Data.Sql.Builders.Caches;
using Util.Data.Sql.Builders.Params;

namespace Util.Data.Dapper.Sql.Builders; 

/// <summary>
/// Oracle Sql生成器
/// </summary>
public class OracleSqlBuilder : SqlBuilderBase {
    /// <summary>
    /// 初始化Oracle Sql生成器
    /// </summary>
    /// <param name="parameterManager">Sql参数管理器</param>
    public OracleSqlBuilder( IParameterManager parameterManager = null )
        : base( parameterManager ) {
    }

    /// <inheritdoc />
    protected override IDialect CreateDialect() {
        return OracleDialect.Instance;
    }

    /// <inheritdoc />
    protected override IColumnCache CreateColumnCache() {
        return OracleColumnCache.Instance;
    }

    /// <inheritdoc />
    public override ISqlBuilder New() {
        return new OracleSqlBuilder( ParameterManager );
    }

    /// <inheritdoc />
    protected override IParameterManager CreateParameterManager() {
        return new OracleParameterManager( Dialect );
    }

    /// <inheritdoc />
    public override ISqlBuilder Clone() {
        var result = new OracleSqlBuilder();
        result.Clone( this );
        return result;
    }
}