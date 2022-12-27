namespace Util.Domain.Extending {
    /// <summary>
    /// 扩展属性
    /// </summary>
    /// <typeparam name="TProperty">扩展属性类型</typeparam>
    public class ExtraProperty<TProperty> where TProperty : class {
        /// <summary>
        /// 扩展属性集合
        /// </summary>
        private ExtraPropertyDictionary _properties;
        /// <summary>
        /// 属性实例
        /// </summary>
        private TProperty _property;
        /// <summary>
        /// 属性名
        /// </summary>
        private readonly string _propertyName;

        /// <summary>
        /// 初始化扩展属性
        /// </summary>
        /// <param name="propertyName">属性名</param>
        public ExtraProperty( string propertyName ) {
            _propertyName = propertyName;
        }

        /// <summary>
        /// 获取属性
        /// </summary>
        /// <param name="properties">扩展属性集合</param>
        public TProperty GetProperty( ExtraPropertyDictionary properties ) {
            _properties = properties ?? new ExtraPropertyDictionary();
            var property = _properties.GetProperty<TProperty>( _propertyName );
            if ( property == null )
                return null;
            if( _property == property )
                return _property;
            _property = property;
            _properties.SetProperty( _propertyName, _property );
            return _property;
        }

        /// <summary>
        /// 设置属性
        /// </summary>
        /// <param name="properties">扩展属性集合</param>
        /// <param name="property">属性实例</param>
        public void SetProperty( ExtraPropertyDictionary properties,TProperty property ) {
            _properties = properties;
            _property = property;
            _properties.SetProperty( _propertyName, _property );
        }
    }
}
