using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Biz.Payments.Alipay.Configs;

namespace Util.Biz.Payments.Alipay.Parameters {
    /// <summary>
    /// 支付宝表单生成器
    /// </summary>
    public class FormBuilder {
        /// <summary>
        /// 表单生成器
        /// </summary>
        private readonly TagBuilder _builder;

        /// <summary>
        /// 初始化支付宝表单生成器
        /// </summary>
        public FormBuilder() {
            _builder = new TagBuilder( "form" );
            _builder.MergeAttribute( "style","display:none" );
        }

        /// <summary>
        /// 表单标识
        /// </summary>
        public string FormId { get; set; } = "formAlipay";

        /// <summary>
        /// 是否自动提交
        /// </summary>
        public bool IsAutoSubmit { get; set; } = true;

        /// <summary>
        /// 添加属性,当属性名已存在则忽略，也可进行替换
        /// </summary>
        /// <param name="name">属性名</param>
        /// <param name="value">属性值</param>
        /// <param name="replaceExisting">是否替换已存在的属性</param>
        public FormBuilder Attribute( string name, string value, bool replaceExisting = false ) {
            _builder.MergeAttribute( name, value.SafeString(), replaceExisting );
            return this;
        }

        /// <summary>
        /// 添加属性,当属性名已存在则忽略
        /// </summary>
        /// <param name="name">属性名</param>
        /// <param name="value">属性值</param>
        public FormBuilder AddAttribute( string name, string value ) {
            if( string.IsNullOrWhiteSpace( value ) )
                return this;
            Attribute( name, value );
            return this;
        }

        /// <summary>
        /// 添加input标签
        /// </summary>
        /// <param name="name">属性名</param>
        /// <param name="value">属性值</param>
        public FormBuilder AddInput( string name, string value ) {
            if( string.IsNullOrWhiteSpace( value ) )
                return this;
            var inputBuilder = new TagBuilder( "input" );
            inputBuilder.MergeAttribute( "name", name );
            inputBuilder.MergeAttribute( "value", value );
            _builder.InnerHtml.AppendHtml( inputBuilder );
            return this;
        }

        /// <summary>
        /// 添加参数生成器
        /// </summary>
        /// <param name="builder">参数生成器</param>
        public FormBuilder AddParam( AlipayParameterBuilder builder ) {
            builder.CheckNull( nameof( builder ) );
            AddProperties( builder );
            AddInputs( builder );
            AddSubmitButton();
            return this;
        }

        /// <summary>
        /// 添加属性列表
        /// </summary>
        private void AddProperties( AlipayParameterBuilder builder ) {
            AddAttribute( "id", FormId );
            AddAttribute( "name", FormId );
            AddAttribute( "action", builder.Config.GetGatewayUrl() );
            AddAttribute( "charset", builder.GetValue( AlipayConst.Charset ).SafeString() );
            AddAttribute( "method", "POST" );
        }

        /// <summary>
        /// 添加input列表
        /// </summary>
        private void AddInputs( AlipayParameterBuilder builder ) {
            foreach( var item in builder.GetDictionary( true ) )
                AddInput( item.Key, item.Value.SafeString() );
        }

        /// <summary>
        /// 添加交按钮
        /// </summary>
        private void AddSubmitButton() {
            _builder.InnerHtml.AppendHtml( CreateSubmitButton() );
        }

        /// <summary>
        /// 创建提交按钮
        /// </summary>
        private TagBuilder CreateSubmitButton() {
            var builder = new TagBuilder( "input" );
            builder.MergeAttribute( "type", "submit" );
            builder.MergeAttribute( "value", "提交" );
            builder.MergeAttribute( "style", "display:none;" );
            return builder;
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        public string Result() {
            using( var writer = new StringWriter() ) {
                _builder.WriteTo( writer, NullHtmlEncoder.Default );
                if( IsAutoSubmit ) {
                    var scriptBuilder = CreateScript();
                    scriptBuilder.WriteTo( writer, NullHtmlEncoder.Default );
                }
                return writer.ToString();
            }
        }

        /// <summary>
        /// 创建提交脚本
        /// </summary>
        private TagBuilder CreateScript() {
            var builder = new TagBuilder( "script" );
            builder.InnerHtml.AppendHtml( $"document.forms['{FormId}'].submit();" );
            return builder;
        }

        /// <summary>
        /// 获取Html结果
        /// </summary>
        public override string ToString() {
            return Result();
        }
    }
}
