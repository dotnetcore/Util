using System;
using Util.Dates;
using Util.Domain.Extending;
using Util.Helpers;

namespace Util.Domain {
    /// <summary>
    /// 扩展属性字典扩展
    /// </summary>
    public static class ExtraPropertyDictionaryExtensions {
        /// <summary>
        /// 获取属性
        /// </summary>
        /// <param name="source">扩展属性字典</param>
        /// <param name="name">属性名</param>
        public static TProperty GetProperty<TProperty>( this ExtraPropertyDictionary source, string name ) {
            source.CheckNull( nameof( source ) );
            if( source.ContainsKey( name ) == false )
                return default;
            var value = source[name];
            if ( value is DateTime dateValue && TimeOptions.IsUseUtc )
                value = Time.UtcToLocalTime( dateValue );
            return Util.Helpers.Convert.To<TProperty>( value );
        }

        /// <summary>
        /// 设置属性,如果存在则先移除旧属性,当值为null时移除该属性
        /// </summary>
        /// <param name="source">扩展属性字典</param>
        /// <param name="name">属性名</param>
        /// <param name="value">属性值</param>
        public static ExtraPropertyDictionary SetProperty( this ExtraPropertyDictionary source, string name, object value ) {
            source.CheckNull( nameof( source ) );
            source.RemoveProperty( name );
            if ( value == null )
                return source;
            source[name] = GetPropertyValue(source,value);
            return source;
        }

        /// <summary>
        /// 获取属性值
        /// </summary>
        private static object GetPropertyValue( ExtraPropertyDictionary source, object value ) {
            if ( value is string && source.IsTrimString )
                return value.SafeString();
            if ( value is DateTime dateValue && TimeOptions.IsUseUtc )
                return Time.Normalize( dateValue );
            return value;
        }

        /// <summary>
        /// 移除属性
        /// </summary>
        /// <param name="source">扩展属性字典</param>
        /// <param name="name">属性名</param>
        public static ExtraPropertyDictionary RemoveProperty( this ExtraPropertyDictionary source, string name ) {
            source.CheckNull( nameof( source ) );
            if( source.ContainsKey( name ) )
                source.Remove( name );
            return source;
        }
    }
}
