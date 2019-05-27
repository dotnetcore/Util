using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Util.Ui.Angular.Forms.Configs;
using Util.Ui.Angular.Resolvers;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Zorro.Forms.Base;
using Util.Ui.Zorro.Forms.Builders;

namespace Util.Ui.Zorro.Forms.Renders {
    /// <summary>
    /// 文本框渲染器
    /// </summary>
    public class TextBoxRender : FormControlRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly TextBoxConfig _config;

        /// <summary>
        /// 初始化文本框渲染器
        /// </summary>
        /// <param name="config">文本框配置</param>
        public TextBoxRender( TextBoxConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            ResolveExpression();
            var builder = CreateBuilder();
            base.Config( builder );
            ConfigTextArea( builder );
            ConfigDatePicker( builder );
            ConfigTextBox( builder );
            ConfigStandalone( builder );
            return builder;
        }

        /// <summary>
        /// 解析属性表达式
        /// </summary>
        private void ResolveExpression() {
            if( _config.Contains( UiConst.For ) == false )
                return;
            var expression = _config.GetValue<ModelExpression>( UiConst.For );
            TextBoxExpressionResolver.Init( expression, _config );
        }

        /// <summary>
        /// 创建标签生成器
        /// </summary>
        private TagBuilder CreateBuilder() {
            if( _config.IsTextArea )
                return new TextAreaWrapperBuilder();
            if( _config.IsDatePicker )
                return new DatePickerWrapperBuilder();
            return new TextBoxWrapperBuilder();
        }

        /// <summary>
        /// 配置多行文本框
        /// </summary>
        private void ConfigTextArea( TagBuilder builder ) {
            if( _config.IsTextArea == false )
                return;
            builder.AddAttribute( "[minRows]", _config.GetValue( UiConst.MinRows ) );
            builder.AddAttribute( "[maxRows]", _config.GetValue( UiConst.MaxRows ) );
        }

        /// <summary>
        /// 配置日期选择框
        /// </summary>
        private void ConfigDatePicker( TagBuilder builder ) {
            if( _config.IsDatePicker == false )
                return;
            var render = new DatePickerRender( _config, builder );
            render.ConfigDatePicker();
        }

        /// <summary>
        /// 配置文本框
        /// </summary>
        private void ConfigTextBox( TagBuilder builder ) {
            ConfigType( builder );
            ConfigReadOnly( builder );
            ConfigValidations( builder );
        }

        /// <summary>
        /// 配置类型
        /// </summary>
        private void ConfigType( TagBuilder builder ) {
            var type = _config.GetValue<TextBoxType?>( UiConst.Type );
            if ( type == TextBoxType.Number )
                return;
            builder.AddAttribute( UiConst.Type, type?.Description() );
        }

        /// <summary>
        /// 配置只读
        /// </summary>
        private void ConfigReadOnly( TagBuilder builder ) {
            builder.AddAttribute( "[readonly]", _config.GetBoolValue( UiConst.ReadOnly ) );
        }

        /// <summary>
        /// 配置验证操作
        /// </summary>
        private void ConfigValidations( TagBuilder builder ) {
            ConfigEmail( builder );
            ConfigMinLength( builder );
            ConfigMaxLength( builder );
            ConfigMin( builder );
            ConfigMax( builder );
            ConfigRegex( builder );
        }

        /// <summary>
        /// 配置Email验证
        /// </summary>
        private void ConfigEmail( TagBuilder builder ) {
            builder.AddAttribute( "emailMessage", _config.GetValue( UiConst.EmailMessage ) );
        }

        /// <summary>
        /// 配置最小长度验证
        /// </summary>
        private void ConfigMinLength( TagBuilder builder ) {
            builder.AddAttribute( "[minLength]", _config.GetValue( UiConst.MinLength ) );
            builder.AddAttribute( "minLengthMessage", _config.GetValue( UiConst.MinLengthMessage ) );
        }

        /// <summary>
        /// 配置最大长度验证
        /// </summary>
        private void ConfigMaxLength( TagBuilder builder ) {
            builder.AddAttribute( "[maxLength]", _config.GetValue( UiConst.MaxLength ) );
        }

        /// <summary>
        /// 配置最小值验证
        /// </summary>
        private void ConfigMin( TagBuilder builder ) {
            builder.AddAttribute( "[min]", _config.GetValue( UiConst.Min ) );
            builder.AddAttribute( "minMessage", _config.GetValue( UiConst.MinMessage ) );
        }

        /// <summary>
        /// 配置最大值验证
        /// </summary>
        private void ConfigMax( TagBuilder builder ) {
            builder.AddAttribute( "[max]", _config.GetValue( UiConst.Max ) );
            builder.AddAttribute( "maxMessage", _config.GetValue( UiConst.MaxMessage ) );
        }

        /// <summary>
        /// 配置正则表达式验证
        /// </summary>
        private void ConfigRegex( TagBuilder builder ) {
            builder.AddAttribute( "pattern", _config.GetValue( UiConst.Regex ) );
            builder.AddAttribute( "patterMessage", _config.GetValue( UiConst.RegexMessage ) );
        }

        /// <summary>
        /// 配置独立
        /// </summary>
        private void ConfigStandalone( TagBuilder builder ) {
            builder.AddAttribute( "[standalone]", _config.GetBoolValue( UiConst.Standalone ) );
        }
    }
}
