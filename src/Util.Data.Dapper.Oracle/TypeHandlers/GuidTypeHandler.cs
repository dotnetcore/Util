namespace Util.Data.Dapper.TypeHandlers; 

/// <summary>
/// Guid类型处理器
/// </summary>
public class GuidTypeHandler : SqlMapper.ITypeHandler {
    /// <summary>
    /// 设置值
    /// </summary>
    /// <param name="parameter">参数</param>
    /// <param name="value">值</param>
    public void SetValue( IDbDataParameter parameter, object value ) {
        var oracleParameter = (OracleParameter)parameter;
        oracleParameter.OracleDbType = OracleDbType.Raw;
        parameter.Value = value;
    }

    /// <summary>
    /// 转换值
    /// </summary>
    /// <param name="destinationType">目标类型</param>
    /// <param name="value">值</param>
    public object Parse( Type destinationType, object value ) {
        return Util.Helpers.Convert.ToGuid( value );
    }
}