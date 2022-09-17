using Util.Ui.Angular.Configs;
using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Comments.Builders {
    /// <summary>
    /// 评论标签生成器
    /// </summary>
    public class CommentBuilder : TagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化评论标签生成器
        /// </summary>
        public CommentBuilder( Config config ) : base( "nz-comment" ) {
            _config = config;
        }

        /// <summary>
        /// 配置作者
        /// </summary>
        public CommentBuilder Author() {
            AttributeIfNotEmpty( "nzAuthor", _config.GetValue( UiConst.Author ) );
            AttributeIfNotEmpty( "[nzAuthor]", _config.GetValue( AngularConst.BindAuthor ) );
            return this;
        }

        /// <summary>
        /// 配置作者
        /// </summary>
        public CommentBuilder Datetime() {
            AttributeIfNotEmpty( "nzDatetime", _config.GetValue( UiConst.Datetime ) );
            AttributeIfNotEmpty( "[nzDatetime]", _config.GetValue( AngularConst.BindDatetime ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            Author().Datetime();
        }
    }
}