using System.Collections.Generic;

namespace Util.Ui.Configs {
    /// <summary>
    /// 配置
    /// </summary>
    public class Config : IConfig {
        /// <summary>
        /// 类
        /// </summary>
        private readonly List<string> _classList;
        /// <summary>
        /// 属性字典
        /// </summary>
        private readonly Dictionary<string, string> _attributes;

        /// <summary>
        /// 初始化配置
        /// </summary>
        public Config() {
            _classList = new List<string>();
            _attributes= new Dictionary<string, string>();
        }

        /// <summary>
        /// 标识
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 文本
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 占位符
        /// </summary>
        public string Placeholder { get; set; }

        /// <summary>
        /// 必填项
        /// </summary>
        public bool Required { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 添加类
        /// </summary>
        public void AddClass( string @class ) {
            if ( string.IsNullOrWhiteSpace( @class ) )
                return;
            if ( _classList.Contains( @class ) )
                return;
            _classList.Add( @class );
        }

        /// <summary>
        /// 获取类列表
        /// </summary>
        public List<string> GetClassList() {
            return _classList;
        }

        /// <summary>
        /// 添加属性
        /// </summary>
        /// <param name="name">属性名</param>
        /// <param name="value">属性值</param>
        public void AddAttribute( string name, string value ) {
            if ( string.IsNullOrWhiteSpace( name ) )
                return;
            if ( _attributes.ContainsKey( name ) )
                _attributes.Remove( name );
            _attributes.Add( name,value );
        }

        /// <summary>
        /// 获取属性集合
        /// </summary>
        public Dictionary<string, string> GetAttributes() {
            return _attributes;
        }

        /// <summary>
        /// 获取属性
        /// </summary>
        /// <param name="name">属性名</param>
        public string GetAttribute( string name ) {
            return _attributes.ContainsKey( name ) ? _attributes[name] : string.Empty;
        }
    }
}
