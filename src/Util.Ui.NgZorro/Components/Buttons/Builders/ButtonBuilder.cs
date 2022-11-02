using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;

namespace Util.Ui.NgZorro.Components.Buttons.Builders {
    /// <summary>
    /// 按钮标签生成器
    /// </summary>
    public class ButtonBuilder : ButtonBuilderBase<ButtonBuilder> {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化按钮标签生成器
        /// </summary>
        public ButtonBuilder( Config config ) : base( config,"button" ) {
            _config = config;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            ConfigButton();
            base.Config();
        }
    }
}
