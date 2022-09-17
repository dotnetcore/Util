using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Comments.Builders {
    /// <summary>
    /// 评论内容标签生成器
    /// </summary>
    public class CommentContentBuilder : TagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化评论内容标签生成器
        /// </summary>
        public CommentContentBuilder( Config config ) : base( "nz-comment-content" ) {
            _config = config;
        }
    }
}