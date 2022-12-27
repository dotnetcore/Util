using Util.Ui.Angular.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Comments.Builders {
    /// <summary>
    /// 评论内容标签生成器
    /// </summary>
    public class CommentContentBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化评论内容标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public CommentContentBuilder( Config config ) : base( config,"nz-comment-content" ) {
            _config = config;
        }
    }
}