using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Zorro.Forms.Builders;

namespace Util.Ui.Zorro.Forms.Renders {
    /// <summary>
    /// 表单标签渲染器
    /// </summary>
    public class FormLabelRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化表单标签渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public FormLabelRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new FormLabelBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        private void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigText( builder );
            ConfigRequired( builder );
            ConfigFor( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置文本
        /// </summary>
        private void ConfigText( TagBuilder builder ) {
            builder.AppendContent( _config.GetValue( UiConst.Text ) );
        }

        /// <summary>
        /// 配置必填样式
        /// </summary>
        private void ConfigRequired( TagBuilder builder ) {
            builder.AddAttribute( "[nzRequired]", _config.GetValue( UiConst.Required ) );
        }

        /// <summary>
        /// 配置For
        /// </summary>
        private void ConfigFor( TagBuilder builder ) {
            builder.AddAttribute( "nzFor", _config.GetValue( UiConst.LabelFor ) );
        }
    }
}
