namespace Util.Data.Metadata {
    /// <summary>
    /// 数据类型转换器工厂
    /// </summary>
    public interface ITypeConverterFactory {
        /// <summary>
        /// 创建数据库元数据服务
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        ITypeConverter Create( DatabaseType dbType );
    }
}
