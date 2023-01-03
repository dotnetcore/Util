using Microsoft.AspNetCore.Html;
using System;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Label.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Label.Renders {
    /// <summary>
    /// 标签渲染器
    /// </summary>
    public class LabelRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化标签渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public LabelRender( Config config ) {
            _config = config ?? throw new ArgumentNullException( nameof( config ) );
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new LabelBuilder( _config );
            builder.Config();
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new LabelRender( _config.Copy() );
        }
    }
}