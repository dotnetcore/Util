using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Avatars.Builders;
using Util.Ui.NgZorro.Components.Comments.Configs;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Avatars.Renders {
    /// <summary>
    /// 头像渲染器
    /// </summary>
    public class AvatarRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化头像渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public AvatarRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new AvatarBuilder( _config );
            builder.Config();
            ConfigCommentAvatar( builder );
            return builder;
        }

        /// <summary>
        /// 配置评论头像
        /// </summary>
        private void ConfigCommentAvatar( TagBuilder builder ) {
            var shareConfig = _config.GetValueFromItems<CommentShareConfig>();
            if( shareConfig == null )
                return;
            builder.Attribute( "nz-comment-avatar" );
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new AvatarRender( _config.Copy() );
        }
    }
}