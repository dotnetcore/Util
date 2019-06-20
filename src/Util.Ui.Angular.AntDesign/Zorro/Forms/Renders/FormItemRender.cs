using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Zorro.Forms.Builders;
using Util.Ui.Zorro.Forms.Configs;

namespace Util.Ui.Zorro.Forms.Renders {
    /// <summary>
    /// 表单项渲染器
    /// </summary>
    public class FormItemRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化表单项渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public FormItemRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new FormItemBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        private void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigGrid( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置栅格
        /// </summary>
        private void ConfigGrid( TagBuilder builder ) {
            var shareConfig = GetShareConfig();
            ConfigGutter( builder, shareConfig );
        }

        /// <summary>
        /// 获取共享配置
        /// </summary>
        private GridShareConfig GetShareConfig() {
            return _config.Context?.GetValueFromItems<GridShareConfig>( GridShareConfig.Key );
        }

        /// <summary>
        /// 配置间隔
        /// </summary>
        private void ConfigGutter( TagBuilder builder, GridShareConfig shareConfig ) {
            var gutter = _config.GetValue( UiConst.Gutter );
            if( gutter.IsEmpty() )
                gutter = shareConfig?.Gutter;
            builder.AddAttribute( "[nzGutter]", gutter );
        }
    }
}
