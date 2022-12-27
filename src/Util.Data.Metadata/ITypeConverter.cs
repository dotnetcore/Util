using System.Data;

namespace Util.Data.Metadata {
    /// <summary>
    /// 数据类型转换器
    /// </summary>
    public interface ITypeConverter {
        /// <summary>
        /// 将数据类型转换为DbType
        /// </summary>
        /// <param name="dataType">数据类型</param>
        /// <param name="length">数据长度</param>
        DbType? ToType( string dataType, int? length = null );
    }
}
