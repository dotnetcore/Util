using Util.Ui.Angular.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.BreadCrumbs.Builders {
    /// <summary>
    /// 面包屑项标签生成器
    /// </summary>
    public class BreadcrumbItemBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化面包屑项标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public BreadcrumbItemBuilder( Config config ) : base( config,"nz-breadcrumb-item" ) {
            _config = config;
        }

        /// <summary>
        /// 配置弹出层
        /// </summary>
        public BreadcrumbItemBuilder Overlay() {
            AttributeIfNotEmpty( "[nzOverlay]", _config.GetValue( UiConst.Overlay ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Overlay();
        }
    }
}