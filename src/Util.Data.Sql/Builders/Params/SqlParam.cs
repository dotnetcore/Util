using System.Data;

namespace Util.Data.Sql.Builders.Params {
    /// <summary>
    /// Sql参数
    /// </summary>
    public class SqlParam {
        /// <summary>
        /// 初始化Sql参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数值</param>
        /// <param name="dbType">参数类型</param>
        /// <param name="direction">参数方向</param>
        /// <param name="size">字段长度</param>
        /// <param name="precision">数值有效位数</param>
        /// <param name="scale">数值小数位数</param>
        public SqlParam( string name, object value, DbType? dbType = null, ParameterDirection? direction = null, int? size = null, byte? precision = null, byte? scale = null ) {
            Name = name;
            Value = value;
            Direction = direction;
            DbType = dbType;
            Size = size;
            Precision = precision;
            Scale = scale;
        }

        /// <summary>
        /// 参数名
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// 参数值
        /// </summary>
        public object Value { get; }
        /// <summary>
        /// 参数方向
        /// </summary>
        public ParameterDirection? Direction { get; }
        /// <summary>
        /// 参数类型
        /// </summary>
        public DbType? DbType { get; }
        /// <summary>
        /// 字段长度
        /// </summary>
        public int? Size { get; }
        /// <summary>
        /// 数值有效位数
        /// </summary>
        public byte? Precision { get; }
        /// <summary>
        /// 数值小数位数
        /// </summary>
        public byte? Scale { get; }
    }
}
