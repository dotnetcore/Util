using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Empties.Builders {
    /// <summary>
    /// 空状态标签生成器
    /// </summary>
    public class EmptyBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化空状态标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public EmptyBuilder( Config config ) : base( config,"nz-empty" ) {
            _config = config;
        }

        /// <summary>
        /// 配置图片
        /// </summary>
        public EmptyBuilder NotFoundImage() {
            AttributeIfNotEmpty( "nzNotFoundImage", _config.GetValue( UiConst.NotFoundImage ) );
            AttributeIfNotEmpty( "[nzNotFoundImage]", _config.GetValue( AngularConst.BindNotFoundImage ) );
            return this;
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        public EmptyBuilder NotFoundContent() {
            AttributeIfNotEmpty( "nzNotFoundContent", _config.GetValue( UiConst.NotFoundContent ) );
            AttributeIfNotEmpty( "[nzNotFoundContent]", _config.GetValue( AngularConst.BindNotFoundContent ) );
            return this;
        }

        /// <summary>
        /// 配置底部内容
        /// </summary>
        public EmptyBuilder NotFoundFooter() {
            AttributeIfNotEmpty( "nzNotFoundFooter", _config.GetValue( UiConst.NotFoundFooter ) );
            AttributeIfNotEmpty( "[nzNotFoundFooter]", _config.GetValue( AngularConst.BindNotFoundFooter ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            NotFoundImage().NotFoundContent().NotFoundFooter();
        }
    }
}