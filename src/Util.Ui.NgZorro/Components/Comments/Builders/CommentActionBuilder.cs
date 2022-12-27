using Util.Ui.Angular.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Comments.Builders {
    /// <summary>
    /// 评论操作标签生成器
    /// </summary>
    public class CommentActionBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化评论操作标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public CommentActionBuilder( Config config ) : base( config,"nz-comment-action" ) {
            _config = config;
        }
    }
}