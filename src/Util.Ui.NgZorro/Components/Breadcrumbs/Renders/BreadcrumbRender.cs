using Util.Ui.Angular.Configs;
using Util.Ui.Angular.Renders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.BreadCrumbs.Builders;
using Util.Ui.NgZorro.Components.PageHeaders.Configs;
using Util.Ui.NgZorro.Configs;

namespace Util.Ui.NgZorro.Components.BreadCrumbs.Renders {
    /// <summary>
    /// 面包屑渲染器
    /// </summary>
    public class BreadcrumbRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化面包屑渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public BreadcrumbRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new BreadcrumbBuilder();
            ConfigSeparator( builder );
            ConfigAutoGenerate( builder );
            ConfigRouteLabel( builder );
            ConfigPageHeader( builder );
            ConfigContent( builder );
            return builder;
        }

        /// <summary>
        /// 配置分隔符
        /// </summary>
        private void ConfigSeparator( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "nzSeparator", _config.GetValue( UiConst.Separator ) );
            builder.AttributeIfNotEmpty( "[nzSeparator]", _config.GetValue( AngularConst.BindSeparator ) );
        }

        /// <summary>
        /// 配置自动生成
        /// </summary>
        private void ConfigAutoGenerate( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "[nzAutoGenerate]", _config.GetBoolValue( UiConst.AutoGenerate ) );
            builder.AttributeIfNotEmpty( "[nzAutoGenerate]", _config.GetValue( AngularConst.BindAutoGenerate ) );
        }

        /// <summary>
        /// 配置路由属性名
        /// </summary>
        private void ConfigRouteLabel( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "nzRouteLabel", _config.GetValue( AntDesignConst.RouteLabel ) );
            builder.AttributeIfNotEmpty( "[nzRouteLabel]", _config.GetValue( AntDesignConst.BindRouteLabel ) );
            builder.AttributeIfNotEmpty( "[nzRouteLabelFn]", _config.GetValue( AntDesignConst.RouteLabelFn ) );
        }

        /// <summary>
        /// 配置页头面包屑
        /// </summary>
        private void ConfigPageHeader( TagBuilder builder ) {
            var shareConfig = _config.GetValueFromItems<PageHeaderShareConfig>();
            if ( shareConfig == null )
                return;
            builder.Attribute( "nz-page-header-breadcrumb" );
        }
    }
}