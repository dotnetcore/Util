using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Material.Lists.Builders;
using Util.Ui.Renders;

namespace Util.Ui.Material.Lists.Renders {
    /// <summary>
    /// 列表内容渲染器
    /// </summary>
    public class ListContentRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化列表内容渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public ListContentRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new ListContentBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigContent( builder );
            builder.Class( _config );
            builder.Style( _config );
        }
    }
}