using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgAlain.Components.I18n.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgAlain.Components.I18n.Renders {
    /// <summary>
    /// i18n多语言渲染器
    /// </summary>
    public class I18nRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化i18n多语言渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public I18nRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new I18nBuilder( _config );
            builder.Config();
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new I18nRender( _config.Copy() );
        }
    }
}