using Util.Domain.Extending;

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
            return Util.Helpers.Convert.To<TProperty>( source[name] );
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
            if ( value != null )
                source[name] = value;
            return source;
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
