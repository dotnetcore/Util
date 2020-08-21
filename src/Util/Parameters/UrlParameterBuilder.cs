using System;
using System.Collections.Generic;
using System.Web;
using Util.Helpers;
using Util.Parameters.Formats;

namespace Util.Parameters {
    /// <summary>
    /// Url参数生成器
    /// </summary>
    public class UrlParameterBuilder : IParameterManager {
        /// <summary>
        /// 参数生成器
        /// </summary>
        private ParameterBuilder ParameterBuilder { get; }

        /// <summary>
        /// 初始化Url参数生成器
        /// </summary>
        public UrlParameterBuilder() : this( "" ) {
        }

        /// <summary>
        /// 初始化Url参数生成器
        /// </summary>
        /// <param name="builder">参数生成器</param>
        public UrlParameterBuilder( ParameterBuilder builder ) {
            ParameterBuilder = builder == null ? new ParameterBuilder() : new ParameterBuilder( builder );
        }

        /// <summary>
        /// 初始化Url参数生成器
        /// </summary>
        /// <param name="builder">Url参数生成器</param>
        public UrlParameterBuilder( UrlParameterBuilder builder ) : this( "", builder ) {
        }

        /// <summary>
        /// 初始化Url参数生成器
        /// </summary>
        /// <param name="url">Url</param>
        /// <param name="builder">Url参数生成器</param>
        public UrlParameterBuilder( string url, UrlParameterBuilder builder = null ) {
            ParameterBuilder = builder == null ? new ParameterBuilder() : new ParameterBuilder( builder.ParameterBuilder );
            LoadUrl( url );
        }

        /// <summary>
        /// 加载Url
        /// </summary>
        public void LoadUrl( string url ) {
            if( string.IsNullOrWhiteSpace( url ) )
                return;
            if( url.Contains( "?" ) )
                url = url.Substring( url.IndexOf( "?", StringComparison.Ordinal ) + 1 );
            var parameters = HttpUtility.ParseQueryString( url );
            foreach( var key in parameters.AllKeys )
                Add( key, parameters.Get( key ) );
        }

        /// <summary>
        /// 从Request加载表单参数
        /// </summary>
        public void LoadForm() {
            var form = Web.Request?.Form;
            if( form == null )
                return;
            foreach( var key in form.Keys ) {
                if( form.ContainsKey( key ) )
                    Add( key, form[key] );
            }
        }

        /// <summary>
        /// 从Request加载查询参数
        /// </summary>
        public void LoadQuery() {
            var query = Web.Request?.Query;
            if( query == null )
                return;
            foreach( var key in query.Keys ) {
                if( query.ContainsKey( key ) )
                    Add( key, query[key] );
            }
        }

        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public UrlParameterBuilder Add( string key, object value ) {
            ParameterBuilder.Add( key, value );
            return this;
        }

        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="name">参数名</param>
        public object GetValue( string name ) {
            return ParameterBuilder.GetValue( name );
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
        /// 获取字典
        /// </summary>
        /// <param name="isSort">是否按参数名排序</param>
        /// <param name="isUrlEncode">是否Url编码</param>
        /// <param name="encoding">字符编码，默认值：UTF-8</param>
        public IDictionary<string, object> GetDictionary( bool isSort = true, bool isUrlEncode = false, string encoding = "UTF-8" ) {
            return ParameterBuilder.GetDictionary( isSort, isUrlEncode, encoding );
        }

        /// <summary>
        /// 获取键值对集合
        /// </summary>
        public IEnumerable<KeyValuePair<string, object>> GetKeyValuePairs() {
            return ParameterBuilder.GetKeyValuePairs();
        }

        /// <summary>
        /// 获取结果，格式：参数名=参数值&amp;参数名=参数值
        /// </summary>
        /// <param name="isSort">是否按参数名排序</param>
        /// <param name="isUrlEncode">是否Url编码</param>
        /// <param name="encoding">字符编码，默认值：UTF-8</param>
        public string Result( bool isSort = false, bool isUrlEncode = false, string encoding = "UTF-8" ) {
            return ParameterBuilder.Result( UrlParameterFormat.Instance, isSort, isUrlEncode, encoding );
        }

        /// <summary>
        /// 连接Url
        /// </summary>
        /// <param name="url">地址</param>
        public string JoinUrl( string url ) {
            return Url.Join( url, Result() );
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void Clear() {
            ParameterBuilder.Clear();
        }

        /// <summary>
        /// 移除参数
        /// </summary>
        /// <param name="key">键</param>
        public bool Remove( string key ) {
            return ParameterBuilder.Remove( key );
        }
    }
}
