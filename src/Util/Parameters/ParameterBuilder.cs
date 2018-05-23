using System;
using System.Collections.Generic;
using System.Linq;
using Util.Helpers;
using Util.Parameters.Formats;

namespace Util.Parameters {
    /// <summary>
    /// 参数生成器
    /// </summary>
    public class ParameterBuilder {
        /// <summary>
        /// 参数集合
        /// </summary>
        private readonly IDictionary<string, string> _params;

        /// <summary>
        /// 初始化参数生成器
        /// </summary>
        public ParameterBuilder() {
            _params = new Dictionary<string, string>();
        }

        /// <summary>
        /// 初始化参数生成器
        /// </summary>
        /// <param name="builder">参数生成器</param>
        public ParameterBuilder( ParameterBuilder builder ) : this( builder.GetDictionary() ) {
        }

        /// <summary>
        /// 初始化参数生成器
        /// </summary>
        /// <param name="dictionary">字典</param>
        public ParameterBuilder( IDictionary<string, string> dictionary ) {
            _params = dictionary == null ? new Dictionary<string, string>() : new Dictionary<string, string>( dictionary );
        }

        /// <summary>
        /// 添加参数，如果参数已存在则替换
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public ParameterBuilder Add( string key, object value ) {
            if( string.IsNullOrWhiteSpace( key ) )
                return this;
            string strValue = GetValue( value ).Trim();
            if( string.IsNullOrWhiteSpace( strValue ) )
                return this;
            key = key.Trim();
            if( _params.ContainsKey( key ) )
                _params[key] = strValue;
            else
                _params.Add( key, strValue );
            return this;
        }

        /// <summary>
        /// 获取值
        /// </summary>
        private string GetValue( object value ) {
            if( value is DateTime dateTime )
                return dateTime.ToString( "yyyy-MM-dd HH:mm:ss" );
            if( value is bool boolValue )
                return boolValue.ToString().ToLower();
            return value.SafeString();
        }

        /// <summary>
        /// 获取字典
        /// </summary>
        public IDictionary<string, string> GetDictionary() {
            return _params.OrderBy( t => t.Key ).ToDictionary( t => t.Key, t => t.Value );
        }

        /// <summary>
        /// 获取键值对集合
        /// </summary>
        public IEnumerable<KeyValuePair<string, string>> GetKeyValuePairs() {
            return _params;
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void Clear() {
            _params.Clear();
        }

        /// <summary>
        /// 移除参数
        /// </summary>
        /// <param name="key">键</param>
        public bool Remove( string key ) {
            return _params.Remove( key );
        }

        /// <summary>
        /// 转换为Json
        /// </summary>
        /// <param name="isConvertToSingleQuotes">是否将双引号转成单引号</param>
        public string ToJson( bool isConvertToSingleQuotes = false ) {
            return Json.ToJson( _params, isConvertToSingleQuotes );
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        /// <param name="format">参数格式化器</param>
        /// <param name="isSort">是否按参数名排序</param>
        public string Result( IParameterFormat format, bool isSort = false ) {
            if( format == null )
                throw new ArgumentNullException( nameof( format ) );
            var result = string.Empty;
            foreach( var param in GetDictionary( isSort ) )
                result = format.Join( result, format.Format( param.Key, param.Value ) );
            return result;
        }

        /// <summary>
        /// 获取字典
        /// </summary>
        private IDictionary<string, string> GetDictionary( bool isSort ) {
            if( isSort == false )
                return _params;
            return new SortedDictionary<string, string>( _params );
        }

        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="name">参数名</param>
        public string GetValue( string name ) {
            if( name.IsEmpty() )
                return string.Empty;
            if( _params.ContainsKey( name ) )
                return _params[name];
            return string.Empty;
        }

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="name">参数名</param>
        public string this[string name] {
            get => GetValue( name );
            set => Add( name, value );
        }

        /// <summary>
        /// 是否空参数
        /// </summary>
        public bool IsEmpty => _params.Count == 0;
    }
}