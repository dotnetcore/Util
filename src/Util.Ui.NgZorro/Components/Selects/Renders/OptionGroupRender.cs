using Util.Ui.Angular.Renders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Selects.Builders;

namespace Util.Ui.NgZorro.Components.Selects.Renders {
    /// <summary>
    /// 选项组渲染器
    /// </summary>
    public class OptionGroupRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化选项组渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public OptionGroupRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new OptionGroupBuilder( _config );
            builder.Config();
            ConfigContent( builder );
            return builder;
        }
    }
}