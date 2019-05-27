using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.SideNavs.Builders;

namespace Util.Ui.Material.SideNavs.Renders {
    /// <summary>
    /// 侧边栏导航容器渲染器
    /// </summary>
    public class SideNavContainerRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化侧边栏导航容器渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public SideNavContainerRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new SideNavContainerBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigContent( builder );
            ConfigFullscreen( builder );
            ConfigAutoSize( builder );
        }

        /// <summary>
        /// 配置全屏
        /// </summary>
        private void ConfigFullscreen( TagBuilder builder ) {
            if ( _config.GetValue<bool>( UiConst.Fullscreen ) )
                builder.AddAttribute( UiConst.Fullscreen );
        }

        /// <summary>
        /// 配置自动调整大小
        /// </summary>
        private void ConfigAutoSize( TagBuilder builder ) {
            builder.AddAttribute( "autosize", _config.GetBoolValue( UiConst.AutoSize ) );
        }
    }
}