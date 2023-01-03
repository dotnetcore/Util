using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Renders;

namespace Util.Ui.Tests.Samples {
    /// <summary>
    /// 测试渲染器
    /// </summary>
    public class TestRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化测试渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public TestRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new TestBuilder(_config);
            builder.Config();
            builder.AttributeIfNotEmpty( UiConst.Name, _config.GetValue( UiConst.Name ) );
            builder.AttributeIfNotEmpty( UiConst.Title, _config.GetValue( UiConst.Title ) );
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new TestRender( _config.Copy() );
        }
    }
}