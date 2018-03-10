using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Material.Dialogs.Builders;
using Util.Ui.Renders;

namespace Util.Ui.Material.Dialogs.Renders {
    /// <summary>
    /// 弹出层内容渲染器
    /// </summary>
    public class DialogContentRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化弹出层内容渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public DialogContentRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new DialogContentBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigContent( builder );
            builder.Style( _config );
            builder.Class( _config );
        }
    }
}