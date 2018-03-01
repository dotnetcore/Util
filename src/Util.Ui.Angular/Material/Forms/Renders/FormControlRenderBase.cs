using System.IO;
using System.Text.Encodings.Web;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Grids.Builders;
using Util.Ui.Renders;

namespace Util.Ui.Material.Forms.Renders {
    /// <summary>
    /// 表单控件渲染器
    /// </summary>
    public abstract class FormControlRenderBase : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化下拉列表渲染器
        /// </summary>
        /// <param name="config">下拉列表配置</param>
        protected FormControlRenderBase( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 渲染
        /// </summary>
        /// <param name="writer">流写入器</param>
        /// <param name="encoder">编码</param>
        public override void WriteTo( TextWriter writer, HtmlEncoder encoder ) {
            RenderBeforeColumn( writer, encoder );
            RenderFormControl( writer, encoder );
            RenderAfterColumn( writer, encoder );
        }

        /// <summary>
        /// 渲染左侧占位列
        /// </summary>
        private void RenderBeforeColumn( TextWriter writer, HtmlEncoder encoder ) {
            if( _config.Contains( UiConst.BeforeColspan ) == false )
                return;
            var builder = new GridColumnBuilder();
            builder.AddColspan( _config, UiConst.BeforeColspan );
            builder.WriteTo( writer, encoder );
        }

        /// <summary>
        /// 渲染表单控件
        /// </summary>
        private void RenderFormControl( TextWriter writer, HtmlEncoder encoder ) {
            if ( _config.Contains( UiConst.Colspan ) == false ) {
                Builder.WriteTo( writer, encoder );
                return;
            }
            var columnBuilder = new GridColumnBuilder();
            columnBuilder.AddColspan( _config, UiConst.Colspan );
            columnBuilder.SetContent( Builder );
            columnBuilder.WriteTo( writer, encoder );
        }

        /// <summary>
        /// 渲染右侧占位列
        /// </summary>
        private void RenderAfterColumn( TextWriter writer, HtmlEncoder encoder ) {
            if( _config.Contains( UiConst.AfterColspan ) == false )
                return;
            var builder = new GridColumnBuilder();
            builder.AddColspan( _config, UiConst.AfterColspan );
            builder.WriteTo( writer, encoder );
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigName( builder );
            ConfigDisabled( builder );
            ConfigPlaceholder( builder );
            ConfigHint( builder );
            ConfigPrefix( builder );
            ConfigSuffix( builder );
            ConfigModel( builder );
            ConfigRequired( builder );
            ConfigEvents( builder );
        }

        /// <summary>
        /// 配置名称
        /// </summary>
        private void ConfigName( TagBuilder builder ) {
            builder.AddAttribute( UiConst.Name, _config.GetValue( UiConst.Name ) );
        }

        /// <summary>
        /// 配置禁用
        /// </summary>
        private void ConfigDisabled( TagBuilder builder ) {
            builder.AddAttribute( "[disabled]", _config.GetBoolValue( UiConst.Disabled ) );
        }

        /// <summary>
        /// 配置占位符
        /// </summary>
        private void ConfigPlaceholder( TagBuilder builder ) {
            builder.AddAttribute( UiConst.Placeholder, _config.GetValue( UiConst.Placeholder ) );
            builder.AddAttribute( "floatPlaceholder", _config.GetValue<FloatType?>( MaterialConst.FloatPlaceholder )?.Description() );
        }

        /// <summary>
        /// 配置提示
        /// </summary>
        private void ConfigHint( TagBuilder builder ) {
            builder.AddAttribute( "startHint", _config.GetValue( MaterialConst.StartHint ) );
            builder.AddAttribute( "endHint", _config.GetValue( MaterialConst.EndHint ) );
        }

        /// <summary>
        /// 配置前缀
        /// </summary>
        private void ConfigPrefix( TagBuilder builder ) {
            builder.AddAttribute( "prefixText", _config.GetValue( UiConst.Prefix ) );
        }

        /// <summary>
        /// 配置后缀
        /// </summary>
        private void ConfigSuffix( TagBuilder builder ) {
            builder.AddAttribute( "suffixText", _config.GetValue( MaterialConst.SuffixText ) );
            builder.AddAttribute( "suffixFontAwesomeIcon", _config.GetValue<FontAwesomeIcon?>( MaterialConst.SuffixFontAwesomeIcon )?.Description() );
            builder.AddAttribute( "suffixMaterialIcon", _config.GetValue<MaterialIcon?>( MaterialConst.SuffixMaterialIcon )?.Description() );
            builder.AddAttribute( "(onSuffixIconClick)", _config.GetValue( MaterialConst.OnSuffixIconClick ) );
        }

        /// <summary>
        /// 配置模型绑定
        /// </summary>
        private void ConfigModel( TagBuilder builder ) {
            builder.AddAttribute( "[(model)]", _config.GetValue( UiConst.Model ) );
        }

        /// <summary>
        /// 配置必填项
        /// </summary>
        private void ConfigRequired( TagBuilder builder ) {
            builder.AddAttribute( "[required]", _config.GetBoolValue( UiConst.Required ) );
            builder.AddAttribute( "requiredMessage", _config.GetValue( UiConst.RequiredMessage ) );
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        private void ConfigEvents( TagBuilder builder ) {
            builder.AddAttribute( "(onChange)", _config.GetValue( UiConst.OnChange ) );
            builder.AddAttribute( "(onFocus)", _config.GetValue( UiConst.OnFocus ) );
            builder.AddAttribute( "(onBlur)", _config.GetValue( UiConst.OnBlur ) );
            builder.AddAttribute( "(onKeyup)", _config.GetValue( UiConst.OnKeyup ) );
            builder.AddAttribute( "(onKeydown)", _config.GetValue( UiConst.OnKeydown ) );
        }
    }
}
