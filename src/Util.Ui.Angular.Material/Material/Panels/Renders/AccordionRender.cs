using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Panels.Builders;

namespace Util.Ui.Material.Panels.Renders {
    /// <summary>
    /// 手风琴渲染器
    /// </summary>
    public class AccordionRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化手风琴渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public AccordionRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new AccordionBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigMultiple( builder );
            ConfigDisplayMode( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置多展开状态
        /// </summary>
        private void ConfigMultiple( TagBuilder builder ) {
            builder.AddAttribute( "multi", _config.GetBoolValue( UiConst.Multiple ) );
        }

        /// <summary>
        /// 配置显示模式
        /// </summary>
        private void ConfigDisplayMode( TagBuilder builder ) {
            builder.AddAttribute( "displayMode", _config.GetBoolValue( MaterialConst.DisplayMode ) );
        }
    }
}