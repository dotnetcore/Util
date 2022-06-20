namespace Util.Data.Sql.Builders.Params {
    /// <summary>
    /// 参数字面值解析器
    /// </summary>
    public interface IParamLiteralsResolver {
        /// <summary>
        /// 获取参数字面值
        /// </summary>
        /// <param name="value">参数值</param>
        string GetParamLiterals( object value );
    }
}
