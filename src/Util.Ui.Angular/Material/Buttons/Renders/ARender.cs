using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Buttons.Builders;

namespace Util.Ui.Material.Buttons.Renders {
    /// <summary>
    /// 链接渲染器
    /// </summary>
    public class ARender : ButtonRender {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化链接渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public ARender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new AWrapperBuilder();
            Config( builder );
            builder.AddAttribute( UiConst.Link, _config.GetValue( UiConst.Link ) );
            return builder;
        }
    }
}
