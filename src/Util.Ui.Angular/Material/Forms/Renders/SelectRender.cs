using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Material.Configs;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Forms.Builders;
using Util.Ui.Material.Forms.Configs;
using Util.Ui.Renders;

namespace Util.Ui.Material.Forms.Renders {
    /// <summary>
    /// 下拉列表渲染器
    /// </summary>
    public class SelectRender : RenderBase {
        /// <summary>
        /// 下拉列表配置
        /// </summary>
        private readonly SelectConfig _config;

        /// <summary>
        /// 初始化下拉列表渲染器
        /// </summary>
        /// <param name="config">下拉列表配置</param>
        public SelectRender( SelectConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override ITagBuilder GetTagBuilder() {
            var builder = new SelectWrapperBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        private void Config( SelectWrapperBuilder builder ) {
            ConfigName( builder );
            ConfigDisabled( builder );
            ConfigUrl( builder );
            ConfigDataSource( builder );
            ConfigPlaceholder( builder );
            ConfigHint( builder );
            ConfigResetOption( builder );
            ConfigMultiple( builder );
            ConfigModel( builder );
            ConfigRequired( builder );
            ConfigTemplate( builder );
            ConfigEvents( builder );
            ConfigPrefix( builder );
            ConfigSuffix( builder );
        }

        /// <summary>
        /// 配置名称
        /// </summary>
        private void ConfigName( SelectWrapperBuilder builder ) {
            builder.AddAttribute( UiConst.Name, _config.GetValue( UiConst.Name ) );
        }

        /// <summary>
        /// 配置禁用
        /// </summary>
        private void ConfigDisabled( SelectWrapperBuilder builder ) {
            builder.AddAttribute( "[disabled]", _config.GetBoolValue( UiConst.Disabled ) );
        }

        /// <summary>
        /// 配置Url
        /// </summary>
        private void ConfigUrl( SelectWrapperBuilder builder ) {
            builder.AddAttribute( UiConst.Url, _config.GetValue( UiConst.Url ) );
        }

        /// <summary>
        /// 配置数据源
        /// </summary>
        private void ConfigDataSource( SelectWrapperBuilder builder ) {
            builder.AddAttribute( "[dataSource]", _config.GetValue( UiConst.DataSource ) );
        }

        /// <summary>
        /// 配置占位符
        /// </summary>
        private void ConfigPlaceholder( SelectWrapperBuilder builder ) {
            builder.AddAttribute( UiConst.Placeholder, _config.GetValue( UiConst.Placeholder ) );
            builder.AddAttribute( "floatPlaceholder", _config.GetValue<FloatType?>( MaterialConst.FloatPlaceholder )?.Description() );
        }

        /// <summary>
        /// 配置提示
        /// </summary>
        private void ConfigHint( SelectWrapperBuilder builder ) {
            builder.AddAttribute( "startHint", _config.GetValue( MaterialConst.StartHint ) );
            builder.AddAttribute( "endHint", _config.GetValue( MaterialConst.EndHint ) );
        }

        /// <summary>
        /// 配置重置项
        /// </summary>
        private void ConfigResetOption( SelectWrapperBuilder builder ) {
            builder.AddAttribute( "[enableResetOption]", _config.GetBoolValue( MaterialConst.EnableResetOption ) );
            builder.AddAttribute( "resetOptionText", _config.GetValue( MaterialConst.ResetOptionText ) );
        }

        /// <summary>
        /// 配置多选
        /// </summary>
        private void ConfigMultiple( SelectWrapperBuilder builder ) {
            builder.AddAttribute( "[multiple]", _config.GetBoolValue( UiConst.Multiple ) );
        }

        /// <summary>
        /// 配置模型绑定
        /// </summary>
        private void ConfigModel( SelectWrapperBuilder builder ) {
            builder.AddAttribute( "[(model)]", _config.GetValue( UiConst.Model ) );
        }

        /// <summary>
        /// 配置必填项
        /// </summary>
        private void ConfigRequired( SelectWrapperBuilder builder ) {
            builder.AddAttribute( "[required]", _config.GetBoolValue( UiConst.Required ) );
            builder.AddAttribute( "requiredMessage", _config.GetValue( UiConst.RequiredMessage ) );
        }

        /// <summary>
        /// 配置显示模板
        /// </summary>
        private void ConfigTemplate( SelectWrapperBuilder builder ) {
            builder.AddAttribute( UiConst.Template, _config.GetValue( UiConst.Template ) );
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        private void ConfigEvents( SelectWrapperBuilder builder ) {
            builder.AddAttribute( "(onChange)", _config.GetValue( UiConst.OnChange ) );
            builder.AddAttribute( "(onFocus)", _config.GetValue( UiConst.OnFocus ) );
            builder.AddAttribute( "(onBlur)", _config.GetValue( UiConst.OnBlur ) );
            builder.AddAttribute( "(onKeydown)", _config.GetValue( UiConst.OnKeydown ) );
        }

        /// <summary>
        /// 配置前缀
        /// </summary>
        private void ConfigPrefix( SelectWrapperBuilder builder ) {
            builder.AddAttribute( "prefixText", _config.GetValue( UiConst.Prefix ) );
        }

        /// <summary>
        /// 配置后缀
        /// </summary>
        private void ConfigSuffix( SelectWrapperBuilder builder ) {
            builder.AddAttribute( "suffixText", _config.GetValue( MaterialConst.SuffixText ) );
            builder.AddAttribute( "suffixFontAwesomeIcon", _config.GetValue<FontAwesomeIcon?>( MaterialConst.SuffixFontAwesomeIcon )?.Description() );
            builder.AddAttribute( "suffixMaterialIcon", _config.GetValue<MaterialIcon?>( MaterialConst.SuffixMaterialIcon )?.Description() );
            builder.AddAttribute( "(onSuffixIconClick)", _config.GetValue( MaterialConst.OnSuffixIconClick ) );
        }
    }
}
