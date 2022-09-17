using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Angular.Renders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.NgZorro.Components.Dividers.Builders;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Dividers.Renders {
    /// <summary>
    /// 分隔线渲染器
    /// </summary>
    public class DividerRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化分隔线渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public DividerRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new DividerBuilder();
            ConfigDashed( builder );
            ConfigType( builder );
            ConfigText( builder );
            ConfigOrientation( builder );
            ConfigPlain( builder );
            ConfigContent( builder );
            return builder;
        }

        /// <summary>
        /// 配置虚线
        /// </summary>
        private void ConfigDashed( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "[nzDashed]", _config.GetBoolValue( UiConst.Dashed ) );
            builder.AttributeIfNotEmpty( "[nzDashed]", _config.GetValue( AngularConst.BindDashed ) );
        }

        /// <summary>
        /// 配置类型
        /// </summary>
        private void ConfigType( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "nzType", _config.GetValue<DividerType?>( UiConst.Type )?.Description() );
            builder.AttributeIfNotEmpty( "[nzType]", _config.GetValue( AngularConst.BindType ) );
        }

        /// <summary>
        /// 配置文字
        /// </summary>
        private void ConfigText( TagBuilder builder ) {
            if( _config.Content.IsEmpty() == false )
                return;
            builder.AttributeIfNotEmpty( "nzText", _config.GetValue( UiConst.Text ) );
            builder.AttributeIfNotEmpty( "[nzText]", _config.GetValue( AngularConst.BindText ) );
        }

        /// <summary>
        /// 配置文字方向
        /// </summary>
        private void ConfigOrientation( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "nzOrientation", _config.GetValue<DividerOrientation?>( UiConst.Orientation )?.Description() );
            builder.AttributeIfNotEmpty( "[nzOrientation]", _config.GetValue( AngularConst.BindOrientation ) );
        }

        /// <summary>
        /// 配置正文样式
        /// </summary>
        private void ConfigPlain( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "[nzPlain]", _config.GetBoolValue( UiConst.Plain ) );
            builder.AttributeIfNotEmpty( "[nzPlain]", _config.GetValue( AngularConst.BindPlain ) );
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        protected override void ConfigContent( TagBuilder builder ) {
            if( _config.Content.IsEmpty() )
                return;
            var id = $"m_{Util.Helpers.Id.Create()}";
            builder.Attribute( "[nzText]", id );
            var templateBuilder = new TemplateBuilder();
            templateBuilder.Attribute( $"#{id}" );
            templateBuilder.AppendContent( _config.Content );
            builder.AppendContent( templateBuilder );
        }
    }
}