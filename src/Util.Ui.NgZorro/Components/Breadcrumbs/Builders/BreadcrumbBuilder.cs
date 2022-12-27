using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.PageHeaders.Configs;
using Util.Ui.NgZorro.Configs;

namespace Util.Ui.NgZorro.Components.BreadCrumbs.Builders {
    /// <summary>
    /// 面包屑标签生成器
    /// </summary>
    public class BreadcrumbBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化面包屑标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public BreadcrumbBuilder( Config config ) : base( config,"nz-breadcrumb" ) {
            _config = config;
        }

        /// <summary>
        /// 配置分隔符
        /// </summary>
        public BreadcrumbBuilder Separator() {
            AttributeIfNotEmpty( "nzSeparator", _config.GetValue( UiConst.Separator ) );
            AttributeIfNotEmpty( "[nzSeparator]", _config.GetValue( AngularConst.BindSeparator ) );
            return this;
        }

        /// <summary>
        /// 配置自动生成
        /// </summary>
        public BreadcrumbBuilder AutoGenerate() {
            AttributeIfNotEmpty( "[nzAutoGenerate]", _config.GetBoolValue( UiConst.AutoGenerate ) );
            AttributeIfNotEmpty( "[nzAutoGenerate]", _config.GetValue( AngularConst.BindAutoGenerate ) );
            return this;
        }

        /// <summary>
        /// 配置路由属性名
        /// </summary>
        public BreadcrumbBuilder RouteLabel() {
            AttributeIfNotEmpty( "nzRouteLabel", _config.GetValue( AntDesignConst.RouteLabel ) );
            AttributeIfNotEmpty( "[nzRouteLabel]", _config.GetValue( AntDesignConst.BindRouteLabel ) );
            AttributeIfNotEmpty( "[nzRouteLabelFn]", _config.GetValue( AntDesignConst.RouteLabelFn ) );
            return this;
        }

        /// <summary>
        /// 配置页头面包屑
        /// </summary>
        public BreadcrumbBuilder PageHeader() {
            var shareConfig = _config.GetValueFromItems<PageHeaderShareConfig>();
            if ( shareConfig != null )
                Attribute( "nz-page-header-breadcrumb" );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Separator().AutoGenerate().RouteLabel().PageHeader();
        }
    }
}