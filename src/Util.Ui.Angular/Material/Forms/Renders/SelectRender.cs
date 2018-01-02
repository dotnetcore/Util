using Util.Ui.Builders;
using Util.Ui.Configs;
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
            ConfigUrl( builder );
            ConfigDataSource( builder );
            ConfigPlaceholder( builder );
            ConfigResetOption( builder );
            ConfigMultiple( builder );
            ConfigModel( builder );
            ConfigRequired( builder );
            ConfigTemplate( builder );
            ConfigOnChange( builder );
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
            builder.AddAttribute( "[selectItems]", _config.GetValue( MaterialConst.SelectItems ) );
            builder.AddAttribute( "[isGroup]", _config.GetBoolValue( UiConst.Group ) );
        }

        /// <summary>
        /// 配置占位提示
        /// </summary>
        private void ConfigPlaceholder( SelectWrapperBuilder builder ) {
            builder.AddAttribute( UiConst.Placeholder, _config.GetValue( UiConst.Placeholder ) );
            builder.AddAttribute( "floatPlaceholder", _config.GetValue<FloatPlaceholder?>( MaterialConst.FloatPlaceholder )?.Description() );
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
        /// 配置变更事件
        /// </summary>
        private void ConfigOnChange( SelectWrapperBuilder builder ) {
            builder.AddAttribute( "(onChange)", _config.GetValue( UiConst.OnChange ) );
        }
    }
}
