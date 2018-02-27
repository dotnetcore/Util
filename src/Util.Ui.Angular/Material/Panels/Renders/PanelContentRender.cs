using Util.Ui.Angular.Builders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Renders;

namespace Util.Ui.Material.Panels.Renders {
    /// <summary>
    /// 面板内容渲染器
    /// </summary>
    public class PanelContentRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化面板内容渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public PanelContentRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new TemplateBuilder();
            builder.AddAttribute( "matExpansionPanelContent" );
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        private void ConfigContent( TagBuilder builder ) {
            if( _config.Content == null )
                return;
            builder.SetContent( _config.Content );
        }
    }
}