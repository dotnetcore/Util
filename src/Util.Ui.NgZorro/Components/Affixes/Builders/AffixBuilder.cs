using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Affixes.Builders {
    /// <summary>
    /// 固钉标签生成器
    /// </summary>
    public class AffixBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化固钉标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public AffixBuilder( Config config ) : base( config,"nz-affix" ) {
            _config = config;
        }

        /// <summary>
        /// 配置顶部偏移量
        /// </summary>
        public AffixBuilder OffsetTop() {
            AttributeIfNotEmpty( "[nzOffsetTop]", _config.GetValue( UiConst.OffsetTop ) );
            AttributeIfNotEmpty( "[nzOffsetTop]", _config.GetValue( AngularConst.BindOffsetTop ) );
            return this;
        }

        /// <summary>
        /// 配置底部偏移量
        /// </summary>
        public AffixBuilder OffsetBottom() {
            AttributeIfNotEmpty( "[nzOffsetBottom]", _config.GetValue( UiConst.OffsetBottom ) );
            AttributeIfNotEmpty( "[nzOffsetBottom]", _config.GetValue( AngularConst.BindOffsetBottom ) );
            return this;
        }

        /// <summary>
        /// 配置目标
        /// </summary>
        public AffixBuilder Target() {
            AttributeIfNotEmpty( "[nzTarget]", _config.GetValue( UiConst.Target ) );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public AffixBuilder Events() {
            AttributeIfNotEmpty( "(nzChange)", _config.GetValue( UiConst.OnChange ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            OffsetTop().OffsetBottom().Target().Events();
        }
    }
}