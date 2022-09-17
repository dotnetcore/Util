using Util.Ui.Angular.Configs;
using Util.Ui.Angular.Renders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Affixes.Builders;

namespace Util.Ui.NgZorro.Components.Affixes.Renders {
    /// <summary>
    /// 固钉渲染器
    /// </summary>
    public class AffixRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化固钉渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public AffixRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new AffixBuilder();
            ConfigOffsetTop( builder );
            ConfigOffsetBottom( builder );
            ConfigTarget( builder );
            ConfigEvents( builder );
            ConfigContent( builder );
            return builder;
        }

        /// <summary>
        /// 配置顶部偏移量
        /// </summary>
        private void ConfigOffsetTop( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "[nzOffsetTop]", _config.GetValue( UiConst.OffsetTop ) );
            builder.AttributeIfNotEmpty( "[nzOffsetTop]", _config.GetValue( AngularConst.BindOffsetTop ) );
        }

        /// <summary>
        /// 配置底部偏移量
        /// </summary>
        private void ConfigOffsetBottom( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "[nzOffsetBottom]", _config.GetValue( UiConst.OffsetBottom ) );
            builder.AttributeIfNotEmpty( "[nzOffsetBottom]", _config.GetValue( AngularConst.BindOffsetBottom ) );
        }

        /// <summary>
        /// 配置目标
        /// </summary>
        private void ConfigTarget( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "[nzTarget]", _config.GetValue( UiConst.Target ) );
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        private void ConfigEvents( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "(nzChange)", _config.GetValue( UiConst.OnChange ) );
        }
    }
}