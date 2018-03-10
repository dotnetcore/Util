using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Material.Lists.Builders;
using Util.Ui.Renders;

namespace Util.Ui.Material.Lists.Renders {
    /// <summary>
    /// 导航列表文本渲染器
    /// </summary>
    public class NavListTextRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化导航列表文本渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public NavListTextRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new NavListTextBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            builder.Style( _config );
            builder.Class( _config );
            ConfigContent( builder );
        }
    }
}