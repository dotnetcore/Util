using Util.Ui.Angular;
using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Zorro.Forms.Helpers;
using Util.Ui.Zorro.Tables.Configs;

namespace Util.Ui.Zorro.Forms.Base {
    /// <summary>
    /// 表单控件渲染器
    /// </summary>
    public abstract class FormControlRenderBase : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化下拉列表渲染器
        /// </summary>
        /// <param name="config">下拉列表配置</param>
        protected FormControlRenderBase( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigTableEdit( builder );
            ConfigName( builder );
            ConfigDisabled( builder );
            ConfigPlaceholder( builder );
            ConfigPrefix( builder );
            ConfigModel( builder );
            ConfigRequired( builder );
            ConfigEvents( builder );
        }

        /// <summary>
        /// 配置表格编辑
        /// </summary>
        private void ConfigTableEdit( TagBuilder builder ) {
            var config = GetColumnShareConfig();
            if( config == null )
                return;
            builder.AddAttribute( "[row]", config.RowId );
        }

        /// <summary>
        /// 是否表格编辑
        /// </summary>
        protected bool IsTableEdit() {
            if( GetColumnShareConfig() == null )
                return false;
            return true;
        }

        /// <summary>
        /// 获取列共享配置
        /// </summary>
        protected ColumnShareConfig GetColumnShareConfig() {
            return _config.GetValueFromItems<ColumnShareConfig>();
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
            builder.NgModel( _config );
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

        /// <summary>
        /// 获取表单项生成器
        /// </summary>
        protected virtual TagBuilder GetFormItemBuilder( TagBuilder controlBuilder ) {
            return FormHelper.CreateFormItemBuilder( _config, controlBuilder );
        }
    }
}
