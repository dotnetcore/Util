namespace Util.Data.Sql.Builders.Params {
    /// <summary>
    /// 获取Sql参数
    /// </summary>
    public interface IGetParameter {
        /// <summary>
        /// 获取Sql参数值
        /// </summary>
        /// <typeparam name="T">参数值类型</typeparam>
        /// <param name="name">参数名</param>
        T GetParam<T>( string name );
    }
}
