using Util.Ui.Angular;
using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.Zorro.Forms.Base {
    /// <summary>
    /// 表单控件渲染器
    /// </summary>
    public abstract class FormControlRenderBase : AngularRenderBase {
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
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigName( builder );
            ConfigDisabled( builder );
            ConfigPlaceholder( builder );
            ConfigPrefix( builder );
            ConfigModel( builder );
            ConfigRequired( builder );
            ConfigEvents( builder );
        }

        /// <summary>
        /// 配置名称
        /// </summary>
        private void ConfigName( TagBuilder builder ) {
            builder.AddAttribute( UiConst.Name, _config.GetValue( UiConst.Name ) );
            builder.AddAttribute( "[name]", _config.GetValue( AngularConst.BindName ) );
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
            builder.AddAttribute( $"[{UiConst.Placeholder}]", _config.GetValue( AngularConst.BindPlaceholder ) );
        }

        /// <summary>
        /// 配置前缀
        /// </summary>
        private void ConfigPrefix( TagBuilder builder ) {
            builder.AddAttribute( "prefixText", _config.GetValue( UiConst.Prefix ) );
        }

        /// <summary>
        /// 配置模型绑定
        /// </summary>
        private void ConfigModel( TagBuilder builder ) {
            builder.AddAttribute( "[(model)]", _config.GetValue( UiConst.Model ) );
            builder.AddAttribute( "[(model)]", _config.GetValue( AngularConst.NgModel ) );
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
