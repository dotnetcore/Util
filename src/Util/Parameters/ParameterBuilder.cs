using System;
using System.Collections.Generic;
using System.Linq;
using Util.Helpers;
using Util.Parameters.Formats;

namespace Util.Parameters {
    /// <summary>
    /// 参数生成器
    /// </summary>
    public class ParameterBuilder : IParameterManager {
        /// <summary>
        /// 参数集合
        /// </summary>
        private readonly IDictionary<string, object> _params;

        /// <summary>
        /// 初始化参数生成器
        /// </summary>
        public ParameterBuilder() {
            _params = new Dictionary<string, object>();
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
        public ParameterBuilder( IDictionary<string, object> dictionary ) {
            _params = dictionary == null ? new Dictionary<string, object>() : new Dictionary<string, object>( dictionary );
        }

        /// <summary>
        /// 添加参数，如果参数已存在则替换
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public ParameterBuilder Add( string key, object value ) {
            if( string.IsNullOrWhiteSpace( key ) )
                return this;
            value = GetValue( value );
            if( string.IsNullOrWhiteSpace( value.SafeString() ) )
                return this;
            key = key.Trim();
            if( _params.ContainsKey( key ) )
                _params[key] = value;
            else
                _params.Add( key, value );
            return this;
        }

        /// <summary>
        /// 获取值
        /// </summary>
        private object GetValue( object value ) {
            if ( value == null )
                return null;
            if( value is DateTime dateTime )
                return dateTime.ToString( "yyyy-MM-dd HH:mm:ss" );
            if( value is bool boolValue )
                return boolValue.ToString().ToLower();
            if ( value is string )
                return value.SafeString().Trim();
            if( value is decimal )
                return value.SafeString();
            return value;
        }

        /// <summary>
        /// 获取字典
        /// </summary>
        /// <param name="isSort">是否按参数名排序</param>
        /// <param name="isUrlEncode">是否Url编码</param>
        /// <param name="encoding">字符编码，默认值：UTF-8</param>
        public IDictionary<string, object> GetDictionary( bool isSort = true, bool isUrlEncode = false, string encoding = "UTF-8" ) {
            var result = _params.ToDictionary( t => t.Key, t => GetEncodeValue( t.Value, isUrlEncode, encoding ) );
            if( isSort == false )
                return result;
            return new SortedDictionary<string, object>( result );
        }

        /// <summary>
        /// 获取编码的值
        /// </summary>
        private object GetEncodeValue( object value, bool isUrlEncode, string encoding ) {
            if( isUrlEncode )
                return Web.UrlEncode( value.SafeString(), encoding );
            return value;
        }

        /// <summary>
        /// 获取键值对集合
        /// </summary>
        public IEnumerable<KeyValuePair<string, object>> GetKeyValuePairs() {
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
        /// <param name="isUrlEncode">是否Url编码</param>
        /// <param name="encoding">字符编码，默认值：UTF-8</param>
        public string Result( IParameterFormat format, bool isSort = false, bool isUrlEncode = false, string encoding = "UTF-8" ) {
            if( format == null )
                throw new ArgumentNullException( nameof( format ) );
            var result = string.Empty;
            foreach( var param in GetDictionary( isSort, isUrlEncode, encoding ) )
                result = format.Join( result, format.Format( param.Key, param.Value ) );
            return result;
        }

        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="name">参数名</param>
        public object GetValue( string name ) {
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
        public object this[string name] {
            get => GetValue( name );
            set => Add( name, value );
        }

        /// <summary>
        /// 是否空参数
        /// </summary>
        public bool IsEmpty => _params.Count == 0;
    }
}