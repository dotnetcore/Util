using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Configs;
using Util.Ui.Material.Forms.Builders;
using Util.Ui.Material.Forms.Configs;

namespace Util.Ui.Material.Forms.Renders {
    /// <summary>
    /// 下拉列表渲染器
    /// </summary>
    public class SelectRender : FormControlRenderBase {
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
        protected override TagBuilder GetTagBuilder() {
            var builder = new SelectWrapperBuilder();
            base.Config( builder );
            ConfigSelect( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        private void ConfigSelect( SelectWrapperBuilder builder ) {
            ConfigUrl( builder );
            ConfigDataSource( builder );
            ConfigResetOption( builder );
            ConfigMultiple( builder );
            ConfigTemplate( builder );
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
        /// 配置显示模板
        /// </summary>
        private void ConfigTemplate( SelectWrapperBuilder builder ) {
            builder.AddAttribute( UiConst.Template, _config.GetValue( UiConst.Template ) );
        }
    }
}
