using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Zorro.Forms.Builders;

namespace Util.Ui.Zorro.Forms.Renders {
    /// <summary>
    /// 开关渲染器
    /// </summary>
    public class SwitchRender : CheckBoxRender {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化开关渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public SwitchRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 创建标签生成器
        /// </summary>
        protected override TagBuilder CreateTagBuilder() {
            return new SwitchBuilder();
        }

        /// <summary>
        /// 配置变更事件
        /// </summary>
        protected override void ConfigOnChange( TagBuilder builder ) {
            builder.AddAttribute( "(ngModelChange)", _config.GetValue( UiConst.OnChange ) );
        }
    }
}
