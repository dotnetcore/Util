using System.Collections.Generic;
using System.Collections.ObjectModel;
using Util.Datas.Queries;

namespace Util.Datas.Sql.Builders.Core {
    /// <summary>
    /// 参数管理器
    /// </summary>
    public class ParameterManager : IParameterManager {
        /// <summary>
        /// Sql方言
        /// </summary>
        private readonly IDialect _dialect;
        /// <summary>
        /// 参数集合
        /// </summary>
        private readonly IDictionary<string, object> _params;
        /// <summary>
        /// 参数索引
        /// </summary>
        private int _paramIndex;

        /// <summary>
        /// 初始化参数管理器
        /// </summary>
        /// <param name="dialect">Sql方言</param>
        /// <param name="data">参数集合</param>
        /// <param name="index">参数索引</param>
        public ParameterManager( IDialect dialect, IDictionary<string, object> data = null, int? index = null ) {
            _dialect = dialect;
            _params = data ?? new Dictionary<string, object>();
            _paramIndex = index.SafeValue();
        }

        /// <summary>
        /// 创建参数名
        /// </summary>
        public string GenerateName() {
            var result =_dialect.GenerateName( _paramIndex );
            _paramIndex += 1;
            return result;
        }

        /// <summary>
        /// 获取参数列表
        /// </summary>
        public IReadOnlyDictionary<string, object> GetParams() {
            return new ReadOnlyDictionary<string, object>( _params );
        }

        /// <summary>
        /// 添加参数,如果参数已存在则替换
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数值</param>
        /// <param name="operator">运算符</param>
        public void Add( string name, object value, Operator? @operator = null ) {
            if( string.IsNullOrWhiteSpace( name ) )
                return;
            name = _dialect.GetParamName( name );
            value = _dialect.GetParamValue( value );
            if ( _params.ContainsKey( name ) )
                _params.Remove( name );
            _params.Add( name, GetValue( value, @operator ) );
        }

        /// <summary>
        /// 获取值
        /// </summary>
        private object GetValue( object value, Operator? @operator ) {
            if( string.IsNullOrWhiteSpace( value.SafeString() ) )
                return value;
            switch( @operator ) {
                case Operator.Contains:
                    return $"%{value}%";
                case Operator.Starts:
                    return $"{value}%";
                case Operator.Ends:
                    return $"%{value}";
                default:
                    return value;
            }
        }

        /// <summary>
        /// 复制副本
        /// </summary>
        public IParameterManager Clone() {
            return new ParameterManager( _dialect, new Dictionary<string, object>( _params ), _paramIndex );
        }

        /// <summary>
        /// 清空参数
        /// </summary>
        public void Clear() {
            _paramIndex = 0;
            _params.Clear();
        }
    }
}
