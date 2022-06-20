namespace Util.Data.Metadata {
    /// <summary>
    /// 列信息
    /// </summary>
    public class ColumnInfo {
        /// <summary>
        /// 列标识
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 列名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 注释
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// 是否主键
        /// </summary>
        public bool IsPrimaryKey { get; set; }
        /// <summary>
        /// 是否自增
        /// </summary>
        public bool IsAutoIncrement { get; set; }
        /// <summary>
        /// 是否可空
        /// </summary>
        public bool? IsNullable { get; set; }
        /// <summary>
        /// 数据类型
        /// </summary>
        public string DataType { get; set; }
        /// <summary>
        /// 长度
        /// </summary>
        public long Length { get; set; }
        /// <summary>
        /// 精度,即数值位数
        /// </summary>
        public int? Precision { get; set; }
        /// <summary>
        /// 小数位数
        /// </summary>
        public int? Scale { get; set; }
    }
}
