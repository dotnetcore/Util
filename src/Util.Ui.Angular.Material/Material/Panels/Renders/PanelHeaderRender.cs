using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Panels.Builders;

namespace Util.Ui.Material.Panels.Renders {
    /// <summary>
    /// 面板头部渲染器
    /// </summary>
    public class PanelHeaderRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化面板头部渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public PanelHeaderRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new PanelHeaderBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigContent( builder );
            ConfigHeight( builder );
        }

        /// <summary>
        /// 配置高度
        /// </summary>
        private void ConfigHeight( TagBuilder builder ) {
            if( _config.Contains( MaterialConst.CollapsedHeight ) )
                builder.AddAttribute( "collapsedHeight", $"{_config.GetValue( MaterialConst.CollapsedHeight )}px" );
            if( _config.Contains( MaterialConst.ExpandedHeight ) )
                builder.AddAttribute( "expandedHeight", $"{_config.GetValue( MaterialConst.ExpandedHeight )}px" );
        }
    }
}