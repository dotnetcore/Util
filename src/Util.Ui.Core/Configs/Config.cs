using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.TagHelpers;

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
        /// 初始化配置
        /// </summary>
        public Config() : this( null, null, null ) {
        }

        /// <summary>
        /// 初始化配置
        /// </summary>
        /// <param name="context">TagHelper上下文</param>
        public Config( Context context ) : this( context.AllAttributes, context.OutputAttributes, context.Content ) {
        }

        /// <summary>
        /// 初始化配置
        /// </summary>
        /// <param name="allAttributes">全部属性集合</param>
        /// <param name="outputAttributes">输出属性集合，TagHelper中未明确定义的属性从该集合获取</param>
        /// <param name="content">内容</param>
        public Config( TagHelperAttributeList allAttributes, TagHelperAttributeList outputAttributes, IHtmlContent content ) {
            _classList = new List<string>();
            AllAttributes = allAttributes ?? new TagHelperAttributeList();
            OutputAttributes = outputAttributes ?? new TagHelperAttributeList();
            Content = content;
        }

        /// <summary>
        /// 全部属性集合
        /// </summary>
        public TagHelperAttributeList AllAttributes { get; }

        /// <summary>
        /// 输出属性集合，TagHelper中未明确定义的属性从该集合获取
        /// </summary>
        public TagHelperAttributeList OutputAttributes { get; }

        /// <summary>
        /// 内容
        /// </summary>
        public IHtmlContent Content { get; set; }

        /// <summary>
        /// 是否验证
        /// </summary>
        public static bool IsValidate { get; set; } = true;

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 最小长度
        /// </summary>
        public int MinLength { get; set; }

        /// <summary>
        /// 最小长度错误消息
        /// </summary>
        public string MinLengthMessage { get; set; }

        /// <summary>
        /// 属性集合是否包含指定属性
        /// </summary>
        /// <param name="name">属性名</param>
        public bool Contains( string name ) {
            return AllAttributes.ContainsName( name );
        }

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="name">属性名</param>
        public string GetValue( string name ) {
            return Contains( name ) ? AllAttributes[name].Value.SafeString() : string.Empty;
        }

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="name">属性名</param>
        public T GetValue<T>( string name ) {
            return Util.Helpers.Convert.To<T>( GetValue( name ) );
        }

        /// <summary>
        /// 获取布尔属性值
        /// </summary>
        /// <param name="name">属性名</param>
        public string GetBoolValue( string name ) {
            return GetValue( name ).SafeString().ToLower();
        }

        /// <summary>
        /// 设置属性
        /// </summary>
        /// <param name="name">属性名</param>
        /// <param name="value">值</param>
        public void SetAttribute( string name,object value ) {
            AllAttributes.SetAttribute( new TagHelperAttribute( name,value ) );
        }

        /// <summary>
        /// 移除属性
        /// </summary>
        /// <param name="name">属性名</param>
        public void Remove( string name ) {
            AllAttributes.RemoveAll( name );
        }

        /// <summary>
        /// 添加类
        /// </summary>
        public void AddClass( string @class ) {
            if( string.IsNullOrWhiteSpace( @class ) )
                return;
            if( _classList.Contains( @class ) )
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
        /// 验证
        /// </summary>
        public string Validate() {
            if ( IsValidate )
                return GetValidateMessage();
            return string.Empty;
        }

        /// <summary>
        /// 获取验证消息
        /// </summary>
        public virtual string GetValidateMessage() {
            return string.Empty;
        }
    }
}
