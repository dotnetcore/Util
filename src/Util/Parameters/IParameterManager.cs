namespace Util.Parameters {
    /// <summary>
    /// 参数服务
    /// </summary>
    public interface IParameterManager {
        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="name">参数名</param>
        object GetValue( string name );
    }
}
