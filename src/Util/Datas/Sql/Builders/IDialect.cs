namespace Util.Datas.Sql.Builders {
    /// <summary>
    /// Sql方言
    /// </summary>
    public interface IDialect {
        /// <summary>
        /// 起始转义标识符
        /// </summary>
        string OpeningIdentifier { get; }
        /// <summary>
        /// 结束转义标识符
        /// </summary>
        string ClosingIdentifier { get; }
        /// <summary>
        /// 安全名称
        /// </summary>
        /// <param name="name">名称</param>
        string SafeName( string name );
        /// <summary>
        /// 获取参数前缀
        /// </summary>
        string GetPrefix();
        /// <summary>
        /// Select子句是否支持As关键字
        /// </summary>
        bool SupportSelectAs();
        /// <summary>
        /// 创建参数名
        /// </summary>
        /// <param name="paramIndex">参数索引</param>
        string GenerateName( int paramIndex );
        /// <summary>
        /// 获取参数名
        /// </summary>
        /// <param name="paramName">参数名</param>
        string GetParamName( string paramName );
        /// <summary>
        /// 获取参数值
        /// </summary>
        /// <param name="paramValue">参数值</param>
        object GetParamValue( object paramValue );
    }
}
