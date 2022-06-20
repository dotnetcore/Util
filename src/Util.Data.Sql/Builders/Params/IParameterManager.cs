using System.Collections.Generic;
using System.Data;

namespace Util.Data.Sql.Builders.Params {
    /// <summary>
    /// Sql参数管理器
    /// </summary>
    public interface IParameterManager {
        /// <summary>
        /// 创建参数名
        /// </summary>
        string GenerateName();
        /// <summary>
        /// 标准化参数名
        /// </summary>
        /// <param name="name">参数名</param>
        string NormalizeName( string name );
        /// <summary>
        /// 添加动态参数
        /// </summary>
        /// <param name="param">动态参数</param>
        void AddDynamicParams( object param );
        /// <summary>
        /// 添加参数,如果参数已存在则替换
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数值</param>
        /// <param name="dbType">参数类型</param>
        /// <param name="direction">参数方向</param>
        /// <param name="size">字段长度</param>
        /// <param name="precision">数值有效位数</param>
        /// <param name="scale">数值小数位数</param>
        void Add( string name, object value = null, DbType? dbType = null, ParameterDirection? direction = null, int? size = null, byte? precision = null, byte? scale = null );
        /// <summary>
        /// 获取动态参数列表
        /// </summary>
        IReadOnlyList<object> GetDynamicParams();
        /// <summary>
        /// 获取参数列表
        /// </summary>
        IReadOnlyList<SqlParam> GetParams();
        /// <summary>
        /// 是否包含参数
        /// </summary>
        /// <param name="name">参数名</param>
        bool Contains( string name );
        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="name">参数名</param>
        SqlParam GetParam( string name );
        /// <summary>
        /// 获取参数值
        /// </summary>
        /// <param name="name">参数名</param>
        object GetValue( string name );
        /// <summary>
        /// 清空参数
        /// </summary>
        void Clear();
        /// <summary>
        /// 复制Sql参数管理器副本
        /// </summary>
        IParameterManager Clone();
    }
}
