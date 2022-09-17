using Util.Ui.Angular.Renders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Comments.Builders;

namespace Util.Ui.NgZorro.Components.Comments.Renders {
    /// <summary>
    /// 评论操作渲染器
    /// </summary>
    public class CommentActionRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化评论操作渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public CommentActionRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new CommentActionBuilder( _config );
            builder.Config();
            ConfigContent( builder );
            return builder;
        }
    }
}