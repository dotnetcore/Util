using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Material.Toolbars.Builders;
using Util.Ui.Renders;

namespace Util.Ui.Material.Toolbars.Renders {
    /// <summary>
    /// 工具栏渲染器
    /// </summary>
    public class ToolbarRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化工具栏渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public ToolbarRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new ToolbarBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            builder.Style( _config );
            ConfigId( builder );
            ConfigContent( builder );
            ConfigColor( builder );
        }

        /// <summary>
        /// 配置颜色
        /// </summary>
        private void ConfigColor( TagBuilder builder ) {
            builder.AddAttribute( "color", _config.GetValue( UiConst.Color )?.ToLower() );
        }
    }
}