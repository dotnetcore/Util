using System.Data;
using Dapper;

namespace Util.Datas.Dapper.Handlers {
    /// <summary>
    /// 字符串类型处理器
    /// </summary>
    public class StringTypeHandler : SqlMapper.TypeHandler<string> {
        /// <summary>
        /// 设置值
        /// </summary>
        /// <param name="parameter">参数</param>
        /// <param name="value">值</param>
        public override void SetValue( IDbDataParameter parameter, string value ) {
            if ( parameter == null )
                return;
            parameter.Value = value;
        }

        /// <summary>
        /// 转换值
        /// </summary>
        /// <param name="value">值</param>
        public override string Parse( object value ) {
            return value?.ToString();
        }
    }
}
