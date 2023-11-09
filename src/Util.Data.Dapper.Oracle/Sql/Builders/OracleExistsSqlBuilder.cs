using Util.Data.Sql;
using Util.Data.Sql.Builders;

namespace Util.Data.Dapper.Sql.Builders; 

/// <summary>
/// 判断是否存在Sql生成器
/// </summary>
public class OracleExistsSqlBuilder : IExistsSqlBuilder {
    /// <summary>
    /// Sql生成器
    /// </summary>
    private readonly ISqlBuilder _sqlBuilder;

    /// <summary>
    /// 初始化判断是否存在Sql生成器
    /// </summary>
    /// <param name="sqlBuilder">Sql生成器</param>
    public OracleExistsSqlBuilder( ISqlBuilder sqlBuilder ) {
        _sqlBuilder = sqlBuilder;
    }

    /// <summary>
    /// 获取Sql
    /// </summary>
    public string GetSql() {
        InitSelect();
        return GetResult();
    }

    /// <summary>
    /// 将Select子句初始化为1
    /// </summary>
    private void InitSelect() {
        _sqlBuilder.ClearSelect();
        _sqlBuilder.AppendSelect( "1" );
    }

    /// <summary>
    /// 获取结果
    /// </summary>
    private string GetResult() {
        var result = new StringBuilder();
        result.AppendLine( "Select Case" );
        result.AppendLine( "  When Exists (" );
        _sqlBuilder.AppendTo( result );
        result.AppendLine( ")" );
        result.AppendLine( "  Then 1" );
        result.AppendLine( "  Else 0 " );
        result.Append( "End" );
        return result.ToString();
    }
}