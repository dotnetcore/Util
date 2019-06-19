using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Zorro.Forms.Builders;

namespace Util.Ui.Zorro.Forms.Renders {
    /// <summary>
    /// 表单项渲染器
    /// </summary>
    public class FormItemRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化表单项渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public FormItemRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new FormItemBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        private void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigContent( builder );
        }
    }
}
