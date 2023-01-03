using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Avatars.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Avatars.Renders {
    /// <summary>
    /// 头像组渲染器
    /// </summary>
    public class AvatarGroupRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化头像组渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public AvatarGroupRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new AvatarGroupBuilder( _config );
            builder.Config();
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new AvatarGroupRender( _config.Copy() );
        }
    }
}